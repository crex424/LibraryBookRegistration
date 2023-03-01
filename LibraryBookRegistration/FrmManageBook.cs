using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryBookRegistration
{
    public partial class FrmManageBook : Form
    {
        public FrmManageBook()
        {
            InitializeComponent();
        }

        private void FrmManageBook_Load(object sender, EventArgs e)
        {
            lviBooks.Columns.Add("ISBN", 120, HorizontalAlignment.Left);
            lviBooks.Columns.Add("Title", 450, HorizontalAlignment.Left);
            lviBooks.Columns.Add("Price", 80, HorizontalAlignment.Left);


            PopulateBookListView();
        }

        private void PopulateBookListView()
        {
            lviBooks.Items.Clear();

            List<Book> books = BookDB.GetAllBooks();

            foreach (Book currBook in books)
            {
                ListViewItem item = new(new[] { currBook.ISBN.ToString(), currBook.Title, currBook.Price.ToString() });
                Tag = currBook;
                lviBooks.Items.Add(item);
            }
        }
    }
}
