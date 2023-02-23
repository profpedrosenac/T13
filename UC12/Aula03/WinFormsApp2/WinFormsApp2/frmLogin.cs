using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btoOK_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" || txtSenha.Text.Trim() == "")
            {
                MessageBox.Show("Erro, usuário ou senha devem ser digitados");
                return;
            }
            if (txtUsuario.Text == "Pedro" && txtSenha.Text == "Legal")
            {
                MessageBox.Show("Seja bem vindo");
                mdiPrincipal frm = new mdiPrincipal();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Erro, usuário ou senha inválidos");
            }
        }
    }
}
