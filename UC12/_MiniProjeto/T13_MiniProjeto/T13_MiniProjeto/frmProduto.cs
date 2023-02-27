using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace T13_MiniProjeto
{
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();
        }

        string stringConexao = frmLogin.stringConexao;

        private void TestarConexao()
        {
            try
            {
                SqlConnection conn = new SqlConnection(stringConexao);
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void CarregarComboCategoria()
        {
            string sql = "select id_Categoria, nome_Categoria from categoria";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            DataTable dt = new DataTable();
            conn.Open();
            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);

                cboIDCategoria.DisplayMember = "id_Categoria";
                cboIDCategoria.DataSource = dt;

                cboNomeCategoria.DisplayMember = "nome_Categoria";
                cboNomeCategoria.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            TestarConexao();
            CarregarComboCategoria();
        }

        private void txtValorCusto_Leave(object sender, EventArgs e)
        {
            float vCusto;
            if (!float.TryParse(txtValorCusto.Text, out vCusto) && txtValorCusto.Text.Trim() != "")
            {
                MessageBox.Show("Erro, valor deve ser numérico e sem formato");
                txtValorCusto.Text = "";
                return;
            }
            else if(txtValorCusto.Text.Trim() == "")
            {
                txtValorCusto.Text = "";
                return;
            }
            txtValorCusto.Text = String.Format("{0:C}",vCusto);
        }

        private void txtValorCusto_Enter(object sender, EventArgs e)
        {
            txtValorCusto.Text = txtValorCusto.Text.Replace("R$ ", "");
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            float vVenda;
            if (!float.TryParse(txtValorVenda.Text, out vVenda) && txtValorVenda.Text.Trim() != "")
            {
                MessageBox.Show("Erro, valor deve ser numérico e sem formato");
                txtValorVenda.Text = "";
                return;
            }
            else if (txtValorVenda.Text.Trim() == "")
            {
                txtValorVenda.Text = "";
                return;
            }
            txtValorVenda.Text = String.Format("{0:C}", vVenda);
        }

        private void txtValorVenda_Enter(object sender, EventArgs e)
        {
            txtValorVenda.Text = txtValorVenda.Text.Replace("R$ ", "");
        }

        private void Limpar()
        {
            txtCodigo.Text = "";
            txtData.Text = "";
            txtNome.Text = "";
            cboIDCategoria.SelectedIndex = -1;
            cboNomeCategoria.SelectedIndex = -1;
            txtValorCusto.Text = "";
            txtValorVenda.Text = "";
            txtDescricao.Text = "";
            txtQtde.Text = "";
            txtOBS.Text = "";
            cboStatus.SelectedIndex = -1;
        }

        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            string vCusto = txtValorCusto.Text;
                                                //R$ 3.486,36
            vCusto = vCusto.Replace("R$ ", ""); //3.486,36
            vCusto = vCusto.Replace(".", "");   //3486,36
            vCusto = vCusto.Replace(",", ".");  //3486.36

            string vVenda = txtValorVenda.Text;
                                                //R$ 3.486,36
            vVenda = vVenda.Replace("R$ ", ""); //3.486,36
            vVenda = vVenda.Replace(".", "");   //3486,36
            vVenda = vVenda.Replace(",", ".");  //3486.36

            string sql = "Insert into produto(" +
                    "nome_Produto," +
                    "id_categoria_Produto," +
                    "valorcusto_Produto," +
                    "valorvenda_Produto," +
                    "descricao_Produto," +
                    "qtde_Produto," +
                    "obs_Produto," +
                    "status_Produto" +
                ")values(" +
                    "'" + txtNome.Text + "'," +
                    "" + cboIDCategoria.Text + "," +
                    "" + vCusto + "," +
                    "" + vVenda + "," +
                    "'" + txtDescricao.Text + "'," +
                    "" + txtQtde.Text + "," +
                    "'" + txtOBS.Text + "'," +
                    "'" + cboStatus.Text + "'" +
                ")Select Scope_Identity()";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            conn.Open();
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Limpar();
                    txtCodigo.Text = reader[0].ToString();
                    btoPesquisar.PerformClick();
                    MessageBox.Show("Cadastro realizado com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btoPesquisar_Click(object sender, EventArgs e)
        {
            string sql = "select * from produto where id_produto = " + txtCodigo.Text;

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCodigo.Text = reader[0].ToString();                    
                    txtNome.Text = reader[1].ToString();
                    cboIDCategoria.Text = reader[2].ToString();

                    txtValorCusto.Text = reader[3].ToString();
                    txtValorCusto.Text = String.Format("{0:C}", float.Parse(txtValorCusto.Text));

                    txtValorVenda.Text = reader[4].ToString();
                    txtValorVenda.Text = String.Format("{0:C}", float.Parse(txtValorVenda.Text));

                    txtDescricao.Text = reader[5].ToString();
                    txtQtde.Text = reader[6].ToString();
                    txtData.Text = reader[7].ToString();
                    txtOBS.Text = reader[8].ToString();
                    cboStatus.Text = reader[9].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btoLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
