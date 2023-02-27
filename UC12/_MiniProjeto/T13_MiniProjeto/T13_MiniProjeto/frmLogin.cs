using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T13_MiniProjeto
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public static string stringConexao = "" +
            "Data Source=localhost;" +
            "Initial Catalog=t13_miniprojeto;" +
            "User ID=sa;" +
            "Password=123456";
        public static string IDUsuario = "";
        public static string NomeUsuario = "";
        public static string LoginUsuario = "";

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

        private void btoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            TesteConexao();
        }
        
        private void btoOK_Click(object sender, EventArgs e)
        {
            Boolean valida = false;
            string sql = "select * from usuario where " +
                "login_Usuario = '" + txtLogin.Text + "' and " +
                "senha_Usuario = '" + txtSenha.Text + "'";

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
                    valida = true;
                    IDUsuario = leitura[0].ToString();
                    NomeUsuario = leitura[1].ToString();
                    LoginUsuario = leitura[2].ToString();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválido");
                    valida = false;
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

            if (valida)
            {
                MDI_Principal frm = new MDI_Principal();
                frm.Show();
                this.Hide();
            }
        }
    }
}
