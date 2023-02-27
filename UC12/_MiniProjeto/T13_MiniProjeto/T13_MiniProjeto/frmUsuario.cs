using System.Data;
using System.Data.SqlClient;

namespace T13_MiniProjeto
{   
    public partial class frmUsuario : Form
    {

        string stringConexao = frmLogin.stringConexao;

        private void TesteConexao()
        {
            SqlConnection conn = new SqlConnection(stringConexao);
            try
            {
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        public frmUsuario()
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
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtConfirmarSenha.Text = "";
            cboStatus.SelectedIndex = -1;
            txtObs.Text = "";
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            TesteConexao();
        }

        private void btoCadastrar_Click(object sender, EventArgs e)
        {
            string sql = "insert into usuario "+
                "(nome_Usuario, login_Usuario, senha_Usuario, obs_Usuario, status_Usuario)" +
                "values" +
                "('"+txtNome.Text+"', '"+txtLogin.Text+"', '"+txtSenha.Text+"', '"+txtObs.Text+"', '"+cboStatus.Text+"')";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Dados cadastrados com suscesso");
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

        private void btoAdd2_Click(object sender, EventArgs e)
        {
            // criar as validações aqui.

            string sql = "insert into usuario " +
                "(nome_Usuario, login_Usuario, senha_Usuario, obs_Usuario, status_Usuario)" +
                "values" +
                "('" + txtNome.Text + "', '" + txtLogin.Text + "', '" + txtSenha.Text + "', '" + txtObs.Text + "', '" + cboStatus.Text + "')" +
                "select SCOPE_IDENTITY()";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = CommandType.Text;
            SqlDataReader leitura;
            conn.Open();

            try
            {
                leitura = command.ExecuteReader();
                if (leitura.Read())
                {
                    btoLimpar.PerformClick();
                    MessageBox.Show("Cadastro realizado com sucesso, ID Gerado: " + leitura[0].ToString());
                    txtCodigo.Text = leitura[0].ToString();
                    btoPesquisar.PerformClick();
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
            string sql = "select * from usuario where id_usuario = " + txtCodigo.Text;

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader leitura;
            conn.Open();

            try
            {
                leitura = cmd.ExecuteReader();
                if (leitura.Read())
                {
                    txtNome.Text = leitura[1].ToString();
                    txtLogin.Text = leitura[2].ToString();
                    txtSenha.Text = leitura[3].ToString();
                    txtConfirmarSenha.Text = leitura[3].ToString();
                    txtObs.Text = leitura[4].ToString();
                    cboStatus.SelectedItem = leitura[5].ToString();
                }
                else
                {
                    MessageBox.Show("Usuário não existe");
                    btoLimpar.PerformClick();
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

        private void btoAlterar_Click(object sender, EventArgs e)
        {
            string sql = "update usuario set " +
                "nome_Usuario = '" + txtNome.Text + "'," +
                "login_Usuario = '" + txtLogin.Text + "'," +
                "senha_Usuario = '" + txtSenha.Text + "'," +
                "obs_Usuario = '" + txtObs.Text + "'," +
                "status_Usuario = '" + cboStatus.Text + "' " +
                "where id_usuario = " + txtCodigo.Text ;

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Dados alterados com sucesso");
                    btoPesquisar.PerformClick();
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

        private void btoExcluir_Click(object sender, EventArgs e)
        {
            string sql = "delete usuario where id_usuario = " + txtCodigo.Text;

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Dados excluidos com sucesso");
                    btoLimpar.PerformClick();
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
    }
}