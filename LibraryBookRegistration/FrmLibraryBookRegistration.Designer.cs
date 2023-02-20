namespace LibraryBookRegistration
{
    partial class FrmLibraryBookRegistration
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.lblBooks = new System.Windows.Forms.Label();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.btnManageRegistration = new System.Windows.Forms.Button();
            this.btnManageBook = new System.Windows.Forms.Button();
            this.btnManageCustomer = new System.Windows.Forms.Button();
            this.lblLibraryBookRegistration = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.dtpRegistration = new System.Windows.Forms.DateTimePicker();
            this.cbxBookTitle = new System.Windows.Forms.ComboBox();
            this.cbxCustomerName = new System.Windows.Forms.ComboBox();
            this.lblAuthors = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(39, 267);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 15);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "Date";
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Location = new System.Drawing.Point(39, 198);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(39, 15);
            this.lblBooks.TabIndex = 22;
            this.lblBooks.Text = "Books";
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Location = new System.Drawing.Point(39, 129);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(64, 15);
            this.lblCustomers.TabIndex = 21;
            this.lblCustomers.Text = "Customers";
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrMsg.Location = new System.Drawing.Point(39, 326);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(0, 15);
            this.lblErrMsg.TabIndex = 20;
            // 
            // btnManageRegistration
            // 
            this.btnManageRegistration.Location = new System.Drawing.Point(290, 272);
            this.btnManageRegistration.Name = "btnManageRegistration";
            this.btnManageRegistration.Size = new System.Drawing.Size(153, 36);
            this.btnManageRegistration.TabIndex = 7;
            this.btnManageRegistration.Text = "&Manage Registrations";
            this.btnManageRegistration.UseVisualStyleBackColor = true;
            this.btnManageRegistration.Click += new System.EventHandler(this.btnManageRegistration_Click);
            // 
            // btnManageBook
            // 
            this.btnManageBook.Location = new System.Drawing.Point(290, 203);
            this.btnManageBook.Name = "btnManageBook";
            this.btnManageBook.Size = new System.Drawing.Size(153, 36);
            this.btnManageBook.TabIndex = 6;
            this.btnManageBook.Text = "Manage &Books";
            this.btnManageBook.UseVisualStyleBackColor = true;
            // 
            // btnManageCustomer
            // 
            this.btnManageCustomer.Location = new System.Drawing.Point(290, 134);
            this.btnManageCustomer.Name = "btnManageCustomer";
            this.btnManageCustomer.Size = new System.Drawing.Size(153, 36);
            this.btnManageCustomer.TabIndex = 5;
            this.btnManageCustomer.Text = "Manage &Customers";
            this.btnManageCustomer.UseVisualStyleBackColor = true;
            // 
            // lblLibraryBookRegistration
            // 
            this.lblLibraryBookRegistration.AutoSize = true;
            this.lblLibraryBookRegistration.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblLibraryBookRegistration.Location = new System.Drawing.Point(97, 54);
            this.lblLibraryBookRegistration.Name = "lblLibraryBookRegistration";
            this.lblLibraryBookRegistration.Size = new System.Drawing.Size(290, 32);
            this.lblLibraryBookRegistration.TabIndex = 12;
            this.lblLibraryBookRegistration.Text = "Library Book Registration";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(39, 355);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(404, 38);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "&Register Book";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // dtpRegistration
            // 
            this.dtpRegistration.Location = new System.Drawing.Point(39, 285);
            this.dtpRegistration.Name = "dtpRegistration";
            this.dtpRegistration.Size = new System.Drawing.Size(200, 23);
            this.dtpRegistration.TabIndex = 3;
            // 
            // cbxBookTitle
            // 
            this.cbxBookTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBookTitle.FormattingEnabled = true;
            this.cbxBookTitle.Location = new System.Drawing.Point(39, 216);
            this.cbxBookTitle.Name = "cbxBookTitle";
            this.cbxBookTitle.Size = new System.Drawing.Size(200, 23);
            this.cbxBookTitle.TabIndex = 2;
            // 
            // cbxCustomerName
            // 
            this.cbxCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCustomerName.FormattingEnabled = true;
            this.cbxCustomerName.Location = new System.Drawing.Point(39, 147);
            this.cbxCustomerName.Name = "cbxCustomerName";
            this.cbxCustomerName.Size = new System.Drawing.Size(200, 23);
            this.cbxCustomerName.TabIndex = 1;
            this.cbxCustomerName.Tag = "";
            // 
            // lblAuthors
            // 
            this.lblAuthors.AutoSize = true;
            this.lblAuthors.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblAuthors.Location = new System.Drawing.Point(12, 9);
            this.lblAuthors.Name = "lblAuthors";
            this.lblAuthors.Size = new System.Drawing.Size(193, 17);
            this.lblAuthors.TabIndex = 24;
            this.lblAuthors.Text = "Tung N. Kim and Campbell Rex";
            // 
            // FrmLibraryBookRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 429);
            this.Controls.Add(this.lblAuthors);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblBooks);
            this.Controls.Add(this.lblCustomers);
            this.Controls.Add(this.lblErrMsg);
            this.Controls.Add(this.btnManageRegistration);
            this.Controls.Add(this.btnManageBook);
            this.Controls.Add(this.btnManageCustomer);
            this.Controls.Add(this.lblLibraryBookRegistration);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.dtpRegistration);
            this.Controls.Add(this.cbxBookTitle);
            this.Controls.Add(this.cbxCustomerName);
            this.Name = "FrmLibraryBookRegistration";
            this.Text = "Library Book Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDate;
        private Label lblBooks;
        private Label lblCustomers;
        private Label lblErrMsg;
        private Button btnManageRegistration;
        private Button btnManageBook;
        private Button btnManageCustomer;
        private Label lblLibraryBookRegistration;
        private Button btnRegister;
        private DateTimePicker dtpRegistration;
        private ComboBox cbxBookTitle;
        private ComboBox cbxCustomerName;
        private Label lblAuthors;
    }
}