namespace WinFormsApp1
{
    public partial class frmEx01 : Form
    {
        public frmEx01()
        {
            InitializeComponent();
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            // Comente seu c�digo!
            Application.Exit();
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtNome.Focus();
        }

        private void btoOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O nome da pessoa �: " + txtNome.Text);
            btoLimpar.PerformClick();
        }
    }
}