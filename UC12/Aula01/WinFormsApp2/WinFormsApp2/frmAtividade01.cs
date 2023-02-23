namespace WinFormsApp2
{
    public partial class frmAtividade01 : Form
    {
        public frmAtividade01()
        {
            InitializeComponent();
        }

        private void btoOK_Click(object sender, EventArgs e)
        {
            txtNome2.Text = txtNome1.Text;
            txtNome1.Text = "";
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtNome1.Text = "";
            txtNome2.Text = "";
            txtNome1.Focus();
        }
    }
}