namespace WinFormsApp2
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtSexo.SelectedIndex = -1;
            txtData.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtUF.SelectedIndex = -1;
            txtSalario.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
        }

        private bool Validar()
        {
            int codigo;
            if (!int.TryParse(txtCodigo.Text, out codigo))
            {
                MessageBox.Show("Erro, código deve ser número");
                txtCodigo.Text = string.Empty;
                txtCodigo.Focus();
                return false;
            }
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Erro, nome deve ser preenchido");
                txtNome.Text = string.Empty;
                txtNome.Focus();
                return false;
            }
            if (txtSexo.SelectedIndex == -1)
            {
                MessageBox.Show("Erro, sexo deve ser preenchido");
                txtSexo.SelectedIndex = -1;
                txtSexo.Focus();
                return false;
            }
            if (txtData.MaskFull == false)
            {
                MessageBox.Show("Erro, Data de nascimento deve ser preenchido");
                txtData.Text = string.Empty;
                txtData.Focus();
                return false;
            }
            if (txtLogradouro.Text.Trim() == "")
            {
                MessageBox.Show("Erro, logradouro deve ser preenchido");
                txtLogradouro.Text = string.Empty;
                txtLogradouro.Focus();
                return false;
            }
            int numero;
            if (!int.TryParse(txtNumero.Text, out numero))
            {
                MessageBox.Show("Erro, número deve ser número");
                txtNumero.Text = string.Empty;
                txtNumero.Focus();
                return false;
            }
            if (txtCEP.MaskFull == false)
            {
                MessageBox.Show("Erro, CEP deve ser preenchido");
                txtCEP.Text = string.Empty;
                txtCEP.Focus();
                return false;
            }
            if (txtCidade.Text.Trim() == "")
            {
                MessageBox.Show("Erro, cidade deve ser preenchido");
                txtCidade.Text = string.Empty;
                txtCidade.Focus();
                return false;
            }
            if (txtUF.SelectedIndex == -1)
            {
                MessageBox.Show("Erro, UF deve ser preenchido");
                txtUF.SelectedIndex = -1;
                txtUF.Focus();
                return false;
            }
            float salario;
            if (!float.TryParse(txtSalario.Text, out salario))
            {
                MessageBox.Show("Erro, salário deve ser preenchido");
                txtSalario.Text = string.Empty;
                txtSalario.Focus();
                return false;
            }
            if (txtTelefone.MaskFull == false)
            {
                MessageBox.Show("Erro, telefone deve ser preenchido");
                txtTelefone.Text = string.Empty;
                txtTelefone.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Erro, email deve ser preenchido");
                txtEmail.Text = string.Empty;
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                lblResult.Text =
                    "Código: " + txtCodigo.Text + "\n" +
                    "Nome: " + txtNome.Text + "\n" +
                    "Sexo: " + txtSexo.Text + "\n" +
                    "Nascimento: " + txtData.Text + "\n" +
                    "Endereço: " + txtLogradouro.Text + "\n" +
                    "Número: " + txtNumero.Text + "\n" +
                    "Complemento: " + txtComplemento.Text + "\n" +
                    "CEP: " + txtCEP.Text + "\n" +
                    "Cidade: " + txtCidade.Text + "\n" +
                    "UF: " + txtUF.Text + "\n" +
                    "Salário: " + txtSalario.Text + "\n" +
                    "Telefone: " + txtTelefone.Text + "\n" +
                    "E-mail: " + txtEmail.Text + "\n" +
                    "Observação: " + txtObs.Text;
            }
        }
    }
}