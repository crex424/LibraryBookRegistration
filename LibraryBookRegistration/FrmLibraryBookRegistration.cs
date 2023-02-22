namespace LibraryBookRegistration
{
    public partial class FrmLibraryBookRegistration : Form
    {
        public FrmLibraryBookRegistration()
        {
            InitializeComponent();
            titleBlink();
        }
        private void FrmLibraryBookRegistration_Load(object sender, EventArgs e)
        {

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
        /// Populates Customer Combo Box - Dropdown List
        /// </summary>
        private void PopulateCustomerComboBox()
        {
            cbxCustomerName.Items.Clear();

            List<Customer> customers = CustomerDB.GetAllCustomers();

            foreach (Customer currCus in customers)
            {
                // Add entire customer object to combo box
                cbxCustomerName.Items.Add(currCus);
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
    }
}