namespace WinFormsApp2
{
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();
        }

        private void cboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPreco.SelectedIndex = cboProduto.SelectedIndex;
        }

        private void btoOK_Click(object sender, EventArgs e)
        {
            float preco;
            int qtde;
            float total;
            if (!float.TryParse(cboPreco.Text, out preco))
            {
                MessageBox.Show("Erro, produto deve ser preenchido");
                return;
            }
            if (!int.TryParse(txtQtde.Text, out qtde))
            {
                MessageBox.Show("Erro, produto deve ser preenchido");
                return;
            }
            total = preco * qtde;
            txtTotal.Text = String.Format("{0:C}",total);
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}