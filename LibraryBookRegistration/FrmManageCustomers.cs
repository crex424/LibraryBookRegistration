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
