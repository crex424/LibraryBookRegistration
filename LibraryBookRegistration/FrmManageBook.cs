using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace LibraryBookRegistration
{
    public partial class FrmManageBook : Form
    {
        public FrmManageBook()
        {
            InitializeComponent();
        }
        /// <summary>
        /// When form is opened this method will be called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmManageBook_Load(object sender, EventArgs e)
        {
            lviBooks.Columns.Add("ISBN", 120, HorizontalAlignment.Left);
            lviBooks.Columns.Add("Title", 450, HorizontalAlignment.Left);
            lviBooks.Columns.Add("Price", 80, HorizontalAlignment.Left);


            PopulateBookListView();
        }
        /// <summary>
        /// Populates the ListView with data from Book table
        /// </summary>
        private void PopulateBookListView()
        {
            lviBooks.Items.Clear();

            List<Book> books = BookDB.GetAllValidBooks();

            foreach (Book currBook in books)
            {
                ListViewItem item = new(new[] { currBook.ISBN.ToString(), currBook.Title, currBook.Price.ToString() });
                Tag = currBook;
                lviBooks.Items.Add(item);
            }
        }
        /// <summary>
        /// Adds valid book to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                string title = DataConfiguration.FormalizeName(txtTitle.Text);
                string isbn = DataConfiguration.RemoveDashesFromISBN(DataConfiguration
                                               .RemoveAllWhiteSpace(txtISBN.Text));
                double price = Convert.ToDouble(DataConfiguration.RemoveAllWhiteSpace(txtPrice.Text));

                Book newBook = new(title, isbn, price);

                BookDB.Add(newBook);
                MessageBox.Show($"'{newBook.Title}' has been added successfully",
                                "Successful!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.None);
                PopulateBookListView();
                clearTextbox();
            }
        }
    }
}
