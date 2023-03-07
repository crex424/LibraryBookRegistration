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
    public partial class FrmManageRegistrations : Form
    {
        public FrmManageRegistrations()
        {
            InitializeComponent();
        }

        private void FrmManageRegistrations_Load(object sender, EventArgs e)
        {
            // Section 1 + 2: Creates columns for Listviews
            CreateListViewColumns();

            // Section 1: Populates Listview to display Customers who have registration(s)
            PopulateCustomerListView();

            // Section 2: Populates Listview to display all registrations
            PopulateRegistrationListView();
        }

        /// <summary>
        /// Creates columns for ListViews
        /// </summary>
        private void CreateListViewColumns()
        {
            // create columns for Registrations listview
            lviRegistrations.Columns.Add("Customer ID", 90, HorizontalAlignment.Left);
            lviRegistrations.Columns.Add("Full Name", 90, HorizontalAlignment.Left);
            lviRegistrations.Columns.Add("ISBN", 150, HorizontalAlignment.Left);
            lviRegistrations.Columns.Add("Book Title", 210, HorizontalAlignment.Left);
            lviRegistrations.Columns.Add("Reg Date", 100, HorizontalAlignment.Left);

            // create collumns for Customer listview
            lviCustomers.Columns.Add("ID", 30, HorizontalAlignment.Left);
            lviCustomers.Columns.Add("FullName", 140, HorizontalAlignment.Left);
            lviCustomers.Columns.Add("DateOfBirth", 75, HorizontalAlignment.Left);

            // create collumns for Books and RegDates listview
            lviBooksAndRegDate.Columns.Add("ISBN", 90, HorizontalAlignment.Left);
            lviBooksAndRegDate.Columns.Add("Book Title", 160, HorizontalAlignment.Left);
            lviBooksAndRegDate.Columns.Add("Price", 55, HorizontalAlignment.Left);
            lviBooksAndRegDate.Columns.Add("Reg Date", 75, HorizontalAlignment.Left);
        }

        /// <summary>
        /// Populates a listbox for all Registrations
        /// </summary>
        private void PopulateRegistrationListView()
        {
            lviRegistrations.Items.Clear();

            List<Registration> registrations = RegistrationDB.GetAllRegistrations();

            foreach (Registration currReg in registrations)
            {
                ListViewItem item = new(new[] { currReg.CustomerID.ToString(),
                                                CustomerDB.GetCustomer(currReg.CustomerID).FullName,
                                                currReg.ISBN,
                                                BookDB.GetBook(currReg.ISBN).Title,
                                                currReg.RegDate.ToShortDateString() }); ; ;
                Tag = currReg;
                lviRegistrations.Items.Add(item);
            }
        }

        /// <summary>
        /// Populates a listview of all Customers who have registrations
        /// </summary>
        private void PopulateCustomerListView()
        {
            lviCustomers.Items.Clear();

            List<Customer> customersWithRegistrations = CustomerDB.GetCustomersWithRegistrations();

            foreach (Customer currCustomer in customersWithRegistrations)
            {
                ListViewItem item = new(new[] { currCustomer.CustomerID.ToString(),
                                                currCustomer.FullName,
                                                currCustomer.DateOfBirth.ToShortDateString() });
                Tag = currCustomer;
                lviCustomers.Items.Add(item);
            }
        }

        
    }
}
