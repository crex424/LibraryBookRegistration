namespace LibraryBookRegistration
{
    partial class FrmManageBook
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
            this.lviBooks = new System.Windows.Forms.ListView();
            this.btnUpdateBook = new System.Windows.Forms.Button();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.lblNotice = new System.Windows.Forms.Label();
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblBookForm = new System.Windows.Forms.Label();
            this.btnReturnToMainForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lviBooks
            // 
            this.lviBooks.AutoArrange = false;
            this.lviBooks.FullRowSelect = true;
            this.lviBooks.GridLines = true;
            this.lviBooks.Location = new System.Drawing.Point(12, 142);
            this.lviBooks.Name = "lviBooks";
            this.lviBooks.Size = new System.Drawing.Size(659, 290);
            this.lviBooks.TabIndex = 5;
            this.lviBooks.UseCompatibleStateImageBehavior = false;
            this.lviBooks.View = System.Windows.Forms.View.Details;
            this.lviBooks.SelectedIndexChanged += new System.EventHandler(this.lviBooks_SelectedIndexChanged);
            // 
            // btnUpdateBook
            // 
            this.btnUpdateBook.Location = new System.Drawing.Point(473, 60);
            this.btnUpdateBook.Name = "btnUpdateBook";
            this.btnUpdateBook.Size = new System.Drawing.Size(90, 29);
            this.btnUpdateBook.TabIndex = 6;
            this.btnUpdateBook.Text = "&Update Book";
            this.btnUpdateBook.UseVisualStyleBackColor = true;
            this.btnUpdateBook.Click += new System.EventHandler(this.btnUpdateBook_Click);
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(581, 60);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(90, 29);
            this.btnDeleteBook.TabIndex = 7;
            this.btnDeleteBook.Text = "&Delete Book";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.ForeColor = System.Drawing.Color.Blue;
            this.lblNotice.Location = new System.Drawing.Point(365, 105);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(0, 15);
            this.lblNotice.TabIndex = 23;
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrMsg.Location = new System.Drawing.Point(365, 105);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(0, 15);
            this.lblErrMsg.TabIndex = 22;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(365, 60);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(90, 29);
            this.btnAddBook.TabIndex = 4;
            this.btnAddBook.Text = "&Add Book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(47, 102);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(295, 23);
            this.txtTitle.TabIndex = 3;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 105);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(29, 15);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Title";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(242, 64);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(203, 68);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(33, 15);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "Price";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(47, 64);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(132, 23);
            this.txtISBN.TabIndex = 1;
            this.txtISBN.TextChanged += new System.EventHandler(this.txtISBN_TextChanged);
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(12, 68);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(32, 15);
            this.lblISBN.TabIndex = 14;
            this.lblISBN.Text = "ISBN";
            // 
            // lblBookForm
            // 
            this.lblBookForm.AutoSize = true;
            this.lblBookForm.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblBookForm.Location = new System.Drawing.Point(268, 11);
            this.lblBookForm.Name = "lblBookForm";
            this.lblBookForm.Size = new System.Drawing.Size(318, 32);
            this.lblBookForm.TabIndex = 12;
            this.lblBookForm.Text = "Book Managing Application";
            // 
            // btnReturnToMainForm
            // 
            this.btnReturnToMainForm.Location = new System.Drawing.Point(12, 20);
            this.btnReturnToMainForm.Name = "btnReturnToMainForm";
            this.btnReturnToMainForm.Size = new System.Drawing.Size(154, 23);
            this.btnReturnToMainForm.TabIndex = 8;
            this.btnReturnToMainForm.Text = "← Return to &Main Form";
            this.btnReturnToMainForm.UseVisualStyleBackColor = true;
            // 
            // FrmManageBook
            // 
            this.AcceptButton = this.btnAddBook;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReturnToMainForm;
            this.ClientSize = new System.Drawing.Size(686, 444);
            this.Controls.Add(this.btnReturnToMainForm);
            this.Controls.Add(this.lviBooks);
            this.Controls.Add(this.btnUpdateBook);
            this.Controls.Add(this.btnDeleteBook);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.lblErrMsg);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.lblBookForm);
            this.Name = "FrmManageBook";
            this.Text = "Book Manager";
            this.Load += new System.EventHandler(this.FrmManageBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lviBooks;
        private Button btnUpdateBook;
        private Button btnDeleteBook;
        private Label lblNotice;
        private Label lblErrMsg;
        private Button btnAddBook;
        private TextBox txtTitle;
        private Label lblTitle;
        private TextBox txtPrice;
        private Label lblPrice;
        private TextBox txtISBN;
        private Label lblISBN;
        private Label lblBookForm;
        private Button btnReturnToMainForm;
    }
}