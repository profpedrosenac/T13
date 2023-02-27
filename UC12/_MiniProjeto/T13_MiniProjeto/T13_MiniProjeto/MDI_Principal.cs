using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T13_MiniProjeto
{
    public partial class MDI_Principal : Form
    {
        private int childFormNumber = 0;

        public MDI_Principal()
        {
            InitializeComponent();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frm = new frmUsuario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduto frm = new frmProduto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MDI_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MDI_Principal_Load(object sender, EventArgs e)
        {
            toolsIDUsuario.Text = frmLogin.IDUsuario;
            toolsNomeUsuario.Text = frmLogin.NomeUsuario;
            toolsLoginUsuario.Text = frmLogin.LoginUsuario;
        }
    }
}
