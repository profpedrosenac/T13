namespace WinFormsApp1
{
    public partial class frmCalculos : Form
    {
        public frmCalculos()
        {
            InitializeComponent();
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtN1.Text = "";
            txtN2.Text = "";
            lblResult.Text = "0";
        }

        float n1;
        float n2;
        float result;
        float porc;
       
        private bool Validar()
        {
            if (float.TryParse(txtN1.Text, out n1) == false)
            {
                MessageBox.Show("Erro, valor do N1 deve ser numérico");
                txtN1.Text = "";
                txtN1.Focus();
                lblResult.Text = "0";
                return false;
            }

            if (float.TryParse(txtN2.Text, out n2) == false)
            {
                MessageBox.Show("Erro, valor do N2 deve ser numérico");
                txtN2.Text = "";
                txtN2.Focus();
                lblResult.Text = "0";
                return false;
            }
            return true;
        }

        private void btoSomar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                result = n1 + n2;
                lblResult.Text = result.ToString();
            }
        }

        private void btoSub_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                result = n1 - n2;
                lblResult.Text = result.ToString();
            }
        }

        private void btoMult_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                result = n1 * n2;
                lblResult.Text = result.ToString();
            }
        }

        private void btoDiv_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                result = n1 / n2;
                lblResult.Text = result.ToString();
            }
        }

        private void btoDesc_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtPorc.Text, out porc))
            {
                if (Validar())
                {
                    result = (n1 + n2) * (1 - porc / 100);
                    lblResult.Text = result.ToString();
                }
            }
        }

        private void btoJuros_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtPorc.Text, out porc))
            {
                if (Validar())
                {
                    result = (n1 + n2) * (1 + porc / 100);
                    lblResult.Text = result.ToString();
                }
            }
        }
    }
}