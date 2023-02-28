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
    public partial class FrmManageCustomers : Form
    {
        public FrmManageCustomers()
        {
            InitializeComponent();
        }
        /// <summary>
        /// When the form loads this method will be called.
        /// Currently this method when called will populate
        /// the Customers ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmManageCustomers_Load(object sender, EventArgs e)
        {
            PopulateCustomerListView();
        }

        /// <summary>
        /// Populates ListView with customer data when called
        /// </summary>
        public void PopulateCustomerListView()
        {
            lviCustomers.Items.Clear();

            List<Customer> customers = CustomerDB.GetAllCustomers();

            foreach (Customer currCustomer in customers)
            {
                lviCustomers.Items.Add(currCustomer.ToString());
            }
        }
    }
}
