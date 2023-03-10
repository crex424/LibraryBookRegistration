using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

            ResetListViews();

            // disable tab index of label controls
            lblRegistrationManagingTool.TabStop = false;
            grbCustomersAndBooks.TabStop = false;
            grbRegistrations.TabStop = false;
            
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

        /// <summary>
        /// Populates a listbox of registered Books of a selected Customer 
        /// </summary>
        /// <param name="customerID"></param>
        private void PopulateBooksAndRegDateListView(int customerID)
        {
            lviBooksAndRegDate.Items.Clear();

            List<Registration> registrationsByID = RegistrationDB.GetRegistrationsByCustomerID(customerID);

            foreach (Registration currReg in registrationsByID)
            {
                ListViewItem item = new(new[] { currReg.ISBN,
                                                BookDB.GetBook(currReg.ISBN).Title,
                                                BookDB.GetBook(currReg.ISBN).Price.ToString("C"),
                                                currReg.RegDate.ToShortDateString() });
                Tag = currReg;
                lviBooksAndRegDate.Items.Add(item);
            }
        }

        private void lviCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show a message when users click on blank part of listbox
            if (lviCustomers.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem selectedCustomer = lviCustomers.SelectedItems[0];
            int customerID = Convert.ToInt32(selectedCustomer.Text);
            PopulateBooksAndRegDateListView(customerID);
        }

        /// <summary>
        /// When listView is selected this method is called.
        /// If there is no selected items then the button to remove selected item
        /// is disabled. If a item is selected then the button is enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lviBooksAndRegDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lviBooksAndRegDate.SelectedItems.Count == 0)
            {
                btnRemoveRegisteredBook.Enabled = false;
            }
            else
            {
                btnRemoveRegisteredBook.Enabled = true;
            }
            
        }
        /// <summary>
        /// When listView is selected this method is called.
        /// If there is no selected items then the button to remove selected item
        /// is disabled. If a item is selected then the button is enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lviRegistrations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lviRegistrations.SelectedItems.Count == 0)
            {
                btnRemoveRegistration.Enabled = false;
            }
            else
            {
                btnRemoveRegistration.Enabled = true;
            }
        }

       
        private void btnRemoveRegistration_Click(object sender, EventArgs e)
        {
            var selectedRegs = lviRegistrations.SelectedItems;

            foreach (ListViewItem currItem in selectedRegs)
            {
                int customerID = Convert.ToInt32(currItem.Text);
                string isbn = currItem.SubItems[2].Text;

                try
                {
                    RegistrationDB.Delete(customerID, isbn);
                    MessageBox.Show($"Registration of '{CustomerDB.GetCustomer(customerID).FullName}' \n" +
                                    $"for '{BookDB.GetBook(isbn).Title}' has been removed succesfully!",
                                    "Successful!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show($"Registration of '{CustomerDB.GetCustomer(customerID).FullName}' \n" +
                                    $"for '{BookDB.GetBook(isbn).Title}' no longer exists",
                                    "Error!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    ResetListViews();
                }
                catch (SqlException)
                {
                    MessageBox.Show("We are having server issues. Please try again later!",
                                    "Error!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }

            ResetListViews();
            lviRegistrations.Focus();
        }

        private void ResetListViews()
        {
            PopulateRegistrationListView();
            PopulateCustomerListView();
            lviBooksAndRegDate.Items.Clear();
            btnRemoveRegisteredBook.Enabled = false;
            btnRemoveRegistration.Enabled = false;
        }

        private void btnRemoveRegisteredBook_Click(object sender, EventArgs e)
        {
            ListViewItem selectedCustomer = lviCustomers.SelectedItems[0];
            int customerID = Convert.ToInt32(selectedCustomer.Text);

            var selectedBooks = lviBooksAndRegDate.SelectedItems;

            foreach (ListViewItem currItem in selectedBooks)
            {
                string isbn = currItem.Text;
                try
                {
                    RegistrationDB.Delete(customerID, isbn);
                    MessageBox.Show($"Registration of '{CustomerDB.GetCustomer(customerID).FullName}' \n" +
                                    $"for '{BookDB.GetBook(isbn).Title}' has been removed succesfully!",
                                    "Successful!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show($"Registration of '{CustomerDB.GetCustomer(customerID).FullName}' \n" +
                                    $"for '{BookDB.GetBook(isbn).Title}' no longer exists",
                                    "Error!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    ResetListViews();
                }
                catch (SqlException)
                {
                    MessageBox.Show("We are having server issues. Please try again later!",
                                    "Error!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }

            ResetListViews();
            lviRegistrations.Focus();
        }
    }
}
