namespace LibraryBookRegistration
{
    public partial class FrmLibraryBookRegistration : Form
    {
        public FrmLibraryBookRegistration()
        {
            InitializeComponent();
            titleBlink();
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
            PopulateCustomerComboBox();
            PopulateBookComboBox();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// makes the application title blink
        /// </summary>
        private async void titleBlink()
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
                // Add title from book object to ComboBox
                cbxBookTitle.Items.Add(currBook.Title);
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
    }
}