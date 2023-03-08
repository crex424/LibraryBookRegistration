namespace LibraryBookRegistration
{
    partial class FrmManageCustomers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lviCustomers = new System.Windows.Forms.ListView();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.lblDOB = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCustomerForm = new System.Windows.Forms.Label();
            this.btnReturnToMainForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lviCustomers
            // 
            this.lviCustomers.FullRowSelect = true;
            this.lviCustomers.GridLines = true;
            this.lviCustomers.Location = new System.Drawing.Point(308, 58);
            this.lviCustomers.Name = "lviCustomers";
            this.lviCustomers.Size = new System.Drawing.Size(403, 241);
            this.lviCustomers.TabIndex = 6;
            this.lviCustomers.UseCompatibleStateImageBehavior = false;
            this.lviCustomers.View = System.Windows.Forms.View.Details;
            this.lviCustomers.SelectedIndexChanged += new System.EventHandler(this.lviCustomers_SelectedIndexChanged);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Location = new System.Drawing.Point(172, 245);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(119, 23);
            this.btnUpdateCustomer.TabIndex = 7;
            this.btnUpdateCustomer.Text = "&Update Customer";
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Location = new System.Drawing.Point(172, 276);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(119, 23);
            this.btnDeleteCustomer.TabIndex = 8;
            this.btnDeleteCustomer.Text = "&Delete Customer";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrMsg.Location = new System.Drawing.Point(13, 213);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(0, 15);
            this.lblErrMsg.TabIndex = 25;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(13, 245);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(139, 54);
            this.btnAddCustomer.TabIndex = 5;
            this.btnAddCustomer.Text = "&Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // dtpDOB
            // 
            this.dtpDOB.CustomFormat = "mm/dd/yyyy";
            this.dtpDOB.Location = new System.Drawing.Point(91, 175);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(200, 23);
            this.dtpDOB.TabIndex = 4;
            this.dtpDOB.Value = new System.DateTime(2023, 2, 18, 0, 0, 0, 0);
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(13, 181);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(73, 15);
            this.lblDOB.TabIndex = 24;
            this.lblDOB.Text = "Date of birth";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(91, 138);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 23);
            this.txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(13, 141);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(63, 15);
            this.lblLastName.TabIndex = 21;
            this.lblLastName.Text = "Last Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(91, 98);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 23);
            this.txtFirstName.TabIndex = 2;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(13, 101);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(64, 15);
            this.lblFirstName.TabIndex = 18;
            this.lblFirstName.Text = "First Name";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(91, 58);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 23);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(13, 61);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(29, 15);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "Title";
            // 
            // lblCustomerForm
            // 
            this.lblCustomerForm.AutoSize = true;
            this.lblCustomerForm.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblCustomerForm.Location = new System.Drawing.Point(258, 8);
            this.lblCustomerForm.Name = "lblCustomerForm";
            this.lblCustomerForm.Size = new System.Drawing.Size(366, 32);
            this.lblCustomerForm.TabIndex = 13;
            this.lblCustomerForm.Text = "Customer Managing Application";
            // 
            // btnReturnToMainForm
            // 
            this.btnReturnToMainForm.Location = new System.Drawing.Point(13, 17);
            this.btnReturnToMainForm.Name = "btnReturnToMainForm";
            this.btnReturnToMainForm.Size = new System.Drawing.Size(154, 23);
            this.btnReturnToMainForm.TabIndex = 9;
            this.btnReturnToMainForm.Text = "← Return to &Main Form";
            this.btnReturnToMainForm.UseVisualStyleBackColor = true;
            // 
            // FrmManageCustomers
            // 
            this.AcceptButton = this.btnAddCustomer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReturnToMainForm;
            this.ClientSize = new System.Drawing.Size(728, 316);
            this.Controls.Add(this.btnReturnToMainForm);
            this.Controls.Add(this.lviCustomers);
            this.Controls.Add(this.btnUpdateCustomer);
            this.Controls.Add(this.btnDeleteCustomer);
            this.Controls.Add(this.lblErrMsg);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCustomerForm);
            this.Name = "FrmManageCustomers";
            this.Text = "Customer Manager";
            this.Load += new System.EventHandler(this.FrmManageCustomers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lviCustomers;
        private Button btnUpdateCustomer;
        private Button btnDeleteCustomer;
        private Label lblErrMsg;
        private Button btnAddCustomer;
        private DateTimePicker dtpDOB;
        private Label lblDOB;
        private TextBox txtLastName;
        private Label lblLastName;
        private TextBox txtFirstName;
        private Label lblFirstName;
        private TextBox txtTitle;
        private Label lblTitle;
        private Label lblCustomerForm;
        private Button btnReturnToMainForm;
    }
}