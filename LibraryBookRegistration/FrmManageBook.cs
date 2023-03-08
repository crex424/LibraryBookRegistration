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
using System.Data.SqlClient;

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

            // disable tab index of some controls
            lblBookForm.TabStop = false;
            lblISBN.TabStop = false;
            lblPrice.TabStop = false;
            lblErrMsg.TabStop = false;
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
                ListViewItem item = new(new[] { currBook.ISBN.ToString(), currBook.Title, currBook.Price.ToString("C") });
                Tag = currBook;
                lviBooks.Items.Add(item);
            }
            // onload or when re-populating listbox after user's activities 
            // enable Add button
            // Update button and Delete button are disabled until an item in listbox selected
            txtISBN.Enabled = true;
            btnAddBook.Enabled = false;
            btnUpdateBook.Enabled = false;
            btnDeleteBook.Enabled = false;
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
                string isbn = DataConfiguration.RemoveDashesFromISBN(DataConfiguration.RemoveAllWhiteSpace(txtISBN.Text));
                double price = Convert.ToDouble(txtPrice.Text);

                Book newBook = new Book(isbn, title, price);

                BookDB.Add(newBook);
                MessageBox.Show($"'{newBook.Title}' has been added successfully",
                                "Successful!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.None);
                PopulateBookListView();
                ClearTextbox();
            }
        }

        private void ClearTextbox()
        {
            txtISBN.Text = "";
            txtISBN.Focus();
            txtTitle.Text = "";
            txtPrice.Text = string.Empty;
            txtISBN.Enabled = true;
            lblErrMsg.Text = "";
        }

        /// <summary>
        /// Validates Book input data
        /// </summary>
        /// <returns>True when all boxes a full and valid, false if not full or valid</returns>
        private bool IsValidInput()
        {
            // all textboxes are filled
            if (Validation.IsPresent(txtISBN) &&
                Validation.IsPresent(txtTitle) &&
                Validation.IsPresent(txtPrice))
            {
                // ISBN is valid and not existed, and price is a number
                if (Validation.IsValidISBN(txtISBN.Text) &&
                    double.TryParse(txtPrice.Text, out double price))
                {
                    if (price < 0)
                    {
                        lblErrMsg.Text = "Price should be greater than or equal to 0!";
                        return false;
                    }
                    lblErrMsg.Text = "";
                    return true;
                }
                else
                {
                    if (!Validation.IsValidISBN(txtISBN.Text))
                    {
                        lblErrMsg.Text = "ISBN must be only number and have a maximum 13 digits!";
                    }
                    if (!double.TryParse(txtPrice.Text, out _))
                    {
                        lblErrMsg.Text = "Price should be a number!";
                    }
                    return false;
                }
            }
            lblErrMsg.Text = "All textboxes shouldn't be empty!";
            return false;
        }
        /// <summary>
        /// Deletes selected book from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            var selectedBooks = lviBooks.SelectedItems;

            foreach (ListViewItem currItem in selectedBooks)
            {
                // Book currBook = new(currItem.Text, currItem.SubItems[1].Text, Convert.ToDouble(currItem.SubItems[2].Text.Substring(1)));
                string isbn = currItem.Text;
                Book currBook = BookDB.GetBook(isbn);
                // count Registrations of selected Book
                int countRegistrationsGroupByISBN = RegistrationDB.CountRegistrationsGroupByISBN(currBook.ISBN);

                try
                {
                    BookDB.Delete(currBook);
                    ClearTextbox();
                    MessageBox.Show($"'{currBook.Title}' has been deleted succesfully!",
                                    "Successful!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show($"'{currBook.Title}' no longer exists",
                                    "Error!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    PopulateBookListView();
                }
                catch (SqlException)
                {
                    if (countRegistrationsGroupByISBN > 0)
                    {
                        MessageBox.Show($"'{currBook.Title}' already has Registrations. \n" +
                                        $"Please remove all Registrations for '{currBook.Title}' first!",
                                        "Error!",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("We are having server issues. Please try again later!",
                                        "Error!",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                    ClearTextbox();
                }
            }

            PopulateBookListView();
        }
        /// <summary>
        /// Updates selected book's data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                string isbn = DataConfiguration.RemoveDashesFromISBN(DataConfiguration.RemoveAllWhiteSpace(txtISBN.Text));
                double price = Convert.ToDouble(txtPrice.Text);
                string title = DataConfiguration.FormalizeName(txtTitle.Text);

                Book updateBook = new(isbn, title, price);

                BookDB.Update(updateBook);
                MessageBox.Show($"'{updateBook.Title}' has been updated successfully!",
                                "Successful!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.None);

                PopulateBookListView();
                ClearTextbox();
            }
        }
        /// <summary>
        /// Displays selected books data in txtBoxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lviBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lviBooks.SelectedItems.Count == 0)
            {
                // MessageBox.Show("Please add or select a Book to update or delete!");
                btnDeleteBook.Enabled = false;
                btnUpdateBook.Enabled = false;
                ClearTextbox();

                return;
            }
            else
            {
                // enable Update and Delete buttons when 1 item is selected
                if (lviBooks.SelectedItems.Count == 1)
                {
                    btnUpdateBook.Enabled = true;
                    btnDeleteBook.Enabled = true;

                    txtISBN.Enabled = false;
                    ListViewItem selectedBook = lviBooks.SelectedItems[0];
                    txtISBN.Text = selectedBook.Text;
                    txtTitle.Text = selectedBook.SubItems[1].Text;
                    txtPrice.Text = selectedBook.SubItems[2].Text.Substring(1);
                    lblErrMsg.Text = "";
                }

                // disable Update button when multiple items are selected
                else
                {
                    btnUpdateBook.Enabled = false;
                    btnDeleteBook.Enabled = true;

                    ClearTextbox();
                }
            }
        }
        /// <summary>
        /// Checks whether input is valid, if it is then enable Add Book button.
        /// If it is not valid disable Add Book button.
        /// </summary>
        private void ToggleAddButton()
        {
            if (IsValidInput())
            {
                btnAddBook.Enabled = true;
            }
            else
            {
                btnAddBook.Enabled = false;
            }
        }
        /// <summary>
        /// When text is changed this method is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtISBN_TextChanged(object sender, EventArgs e)
        {
            ToggleAddButton();
        }
        /// <summary>
        /// When text is changed this method is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            ToggleAddButton();
        }
        /// <summary>
        /// When text is changed this method is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            ToggleAddButton();
        }
    }
}
