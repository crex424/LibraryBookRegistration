namespace LibraryBookRegistration
{
    public partial class FrmLibraryBookRegistration : Form
    {
        public FrmLibraryBookRegistration()
        {
            InitializeComponent();
            titleBlink();
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
        /// Opens FrmManageRegistrations form when clicked
        /// </summary>
        private void btnManageRegistration_Click(object sender, EventArgs e)
        {
            FrmManageRegistrations newManageRegForm = new();
            newManageRegForm.ShowDialog();

        }
    }
}