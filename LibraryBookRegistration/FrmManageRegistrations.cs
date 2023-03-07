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
            // Section 2: Listview to display all Registrations
            CreateListViewColumns();
            PoplulateRegistrationListView();
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
        }

        /// <summary>
        /// Populates a listbox for all Registrations
        /// </summary>
        private void PoplulateRegistrationListView()
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
    }
}
