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
        int cont = 0;
        private void BtoOK_Click(object sender, EventArgs e)
        {
            string user1 = "pedro";
            string pass1 = "123";

            string user2 = "joaquim";
            string pass2 = "123";

            string user3 = "admin";
            string pass3 = "123";


            if ((txtLogin.Text == user1 && txtSenha.Text == pass1) ||
                (txtLogin.Text == user2 && txtSenha.Text == pass2) ||
                (txtLogin.Text == user3 && txtSenha.Text == pass3))
            {
                MessageBox.Show("Seja bem vindo");
                MDIPrincipal frm = new MDIPrincipal();
                frm.Show();
                this.Hide();
            }
            else
            {
                cont++;
                MessageBox.Show("Erro, usuário ou senha inválido\n" +
                    "Tentativa " + cont + " de 3.");
            }

            if (cont == 3)
            {
                MessageBox.Show("Erro, foi esgotado as tentativas, tente novamente mais tarde");
                Application.Exit();
            }
        }
    }
}
