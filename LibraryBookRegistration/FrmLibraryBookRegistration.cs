namespace LibraryBookRegistration
{
    public partial class FrmLibraryBookRegistration : Form
    {
        public FrmLibraryBookRegistration()
        {
            InitializeComponent();
            _ = titleBlink();
        }

        /// <summary>
        /// When the form loads this method will be called.
        /// Currently this method when called will populate 
        /// the Customer ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLibraryBookRegistration_Load(object sender, EventArgs e)
        {
            resetForm();

            // disable tab index of some controls
            lblCustomers.TabStop = false;
            lblBooks.TabStop = false;
            lblDate.TabStop = false;
            lblLibraryBookRegistration.TabStop = false;
            lblErrMsg.TabStop = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // make sure users select a customer and a book to register
            if (cbxCustomerName.SelectedIndex == -1 ||
                cbxBookTitle.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer and a book to register!");
                return;
            }

            Customer selectedCus = (Customer)cbxCustomerName.SelectedItem;
            Book selectedBook = (Book)cbxBookTitle.SelectedItem;
            DateTime regDate = dtpRegistration.Value;

            Registration newReg = new Registration(selectedCus.CustomerID, selectedBook.ISBN, regDate);

            bool result = RegistrationDB.RegisterBook(newReg);
            if (!result)
            {
                MessageBox.Show("We are having server issues. Please try again later!");
            }
            MessageBox.Show($"Registration of '{selectedCus.FullName}' for '{selectedBook.Title}' has been addded succesfully!");

            resetForm();
        }

        /// <summary>
        /// makes the application title blink
        /// </summary>
        private async Task titleBlink()
        {
            while (true)
            {
                await Task.Delay(500);
                lblLibraryBookRegistration.ForeColor = lblLibraryBookRegistration.ForeColor == Color.Red ? Color.Green : Color.Red;
            }
        }

        /// <summary>
        /// Populates Customer ComboBox - Dropdown List
        /// </summary>
        private void PopulateCustomerComboBox()
        {
            cbxCustomerName.Items.Clear();

            List<Customer> customers = CustomerDB.GetAllCustomers();

            foreach (Customer currCus in customers)
            {
                // Add entire customer object to ComboBox
                cbxCustomerName.Items.Add(currCus);
            }
        }

        /// <summary>
        /// Populates Customer ComboBox - DropDown List
        /// </summary>
        private void PopulateBookComboBox()
        {
            cbxBookTitle.Items.Clear();

            List<Book> books = BookDB.GetAllBooks();

            foreach (Book currBook in books)
            {
                currBook.ISBN = DataConfiguration.RemoveAllWhiteSpace(currBook.ISBN);
                currBook.ISBN = DataConfiguration.RemoveDashesFromISBN(currBook.ISBN);

                // Add title from book object to ComboBox
                cbxBookTitle.Items.Add(currBook);
            }
        }

        /// <summary>
        /// Populates combo box for Books not yet registered by a Customer
        /// when users select a customer from Customer combo box
        /// </summary>
        /// <param name="customerID">CustomerID of a Customer</param>
        private void PopulateBookComboBox(int customerID)
        {
            cbxBookTitle.Items.Clear();

            List<Book> booksNotYetRegisterByCustomerID = BookDB.GetBooksNotYetRegisterByCustomerID(customerID);

            foreach (Book currBook in booksNotYetRegisterByCustomerID)
            {
                currBook.ISBN = DataConfiguration.RemoveAllWhiteSpace(currBook.ISBN);
                currBook.ISBN = DataConfiguration.RemoveDashesFromISBN(currBook.ISBN);

                // Add entire book object to combo box
                cbxBookTitle.Items.Add(currBook);
            }

            if (booksNotYetRegisterByCustomerID.Count == 0)
            {
                MessageBox.Show($"There are no books available for {CustomerDB.GetCustomer(customerID).FullName} to register!");
            }
        }

        /// <summary>
        /// Opens FrmManageRegistrations form when clicked
        /// </summary>
        private void btnManageRegistration_Click(object sender, EventArgs e)
        {
            FrmManageRegistrations newManageRegForm = new();
            newManageRegForm.ShowDialog();
        }
        /// <summary>
        /// Opens FrmManageCustomer form when clicked
        /// </summary>
        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            FrmManageCustomers newManageCustomerForm = new();
            newManageCustomerForm.ShowDialog();
        }
        /// <summary>
        /// Opens FrmManageBook form when clicked
        /// </summary>
        private void btnManageBook_Click(object sender, EventArgs e)
        {
            FrmManageBook newManageBookForm = new();
            newManageBookForm.ShowDialog();
        }

        

        /// <summary>
        /// Clears input 
        /// </summary>
        private void resetForm()
        {
            PopulateCustomerComboBox();
            PopulateBookComboBox();
            lblErrMsg.Text = "";
            dtpRegistration.Value = DateTime.Today;
            ToggleRegisterButton();
        }

        /// <summary>
        /// Validates input date
        /// </summary>
        /// <returns>True when all input is valid</returns>
        private bool IsValid()
        {
            if (cbxCustomerName.SelectedIndex != -1 &&
                cbxBookTitle.SelectedIndex != -1 &&
                dtpRegistration.Value >= DateTime.Today)
            {
                lblErrMsg.Text = "";
                return true;
            }
            else
            {
                if (dtpRegistration.Value < DateTime.Today)
                {
                    lblErrMsg.Text = "Date can't be in the past!";
                }
                return false;
            }

        }

        /// <summary>
        /// Enable Register Book Button when all input is valid
        /// Disable when all conditions not met
        /// </summary>
        private void ToggleRegisterButton()
        {
            if (IsValid())
            {
                btnRegister.Enabled = true;
            }
            else
            {
                btnRegister.Enabled = false;
            }
        }

        private void cbxCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleRegisterButton();
            if (cbxCustomerName.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer to show available books to register!");
                return;
            }

            Customer selectedCus = (Customer)cbxCustomerName.SelectedItem;
            PopulateBookComboBox(selectedCus.CustomerID);
        }

        private void cbxBookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleRegisterButton();
        }

        private void dtpRegistration_ValueChanged(object sender, EventArgs e)
        {
            ToggleRegisterButton();
        }
    }
}