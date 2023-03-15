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
    public partial class frmUsuarioPesquisa : Form
    {
        public frmUsuarioPesquisa()
        {
            InitializeComponent();
        }

        string stringConexao = frmLogin.stringConexao;
        public string _codigo;

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

        private void CarregarGridUsuario()
        {
            string sql = "select " +
                    "id_usuario as 'ID'," +
                    "nome_Usuario as 'Nome'," +
                    "login_Usuario as 'Usuario'," +
                    "status_Usuario as 'status' " +
                "from usuario where nome_Usuario like '%" + txtNomePesquisa.Text + "%'";

            SqlConnection conn = new SqlConnection(stringConexao);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            conn.Open();

            try
            {
                adapter.Fill(ds);
                gridUsuario.DataSource = ds.Tables[0];
                gridUsuario.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                gridUsuario.AutoResizeRow(0, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
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

        private void frmUsuarioPesquisa_Load(object sender, EventArgs e)
        {
            TesteConexao();
            CarregarGridUsuario();
        }

        private void gridUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _codigo = gridUsuario.CurrentRow.Cells["ID"].Value.ToString();
            //MessageBox.Show(_codigo);
            this.Close();
        }

        private void txtNomePesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarGridUsuario();
        }
    }
}
