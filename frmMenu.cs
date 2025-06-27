using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PryCepedaIEFI
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario usuario = new frmUsuario();
            usuario.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock stock = new frmStock();
            stock.Show();
        }

        private void rbAdministrador_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdministrador.Checked)
            {

                btnSiguiente.Enabled = true;


            }
            else
            {
                btnSiguiente.Enabled = false;
                rbUsuario.Enabled = false;
            }
        }

        private void rbUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUsuario.Checked)
            {
                btnSiguiente.Enabled = true;
            }
            else
            {
                btnSiguiente.Enabled = false;
                rbAdministrador.Enabled = false;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (rbAdministrador.Checked)
            {
                frmStock stock = new frmStock();
                stock.ShowDialog();
            }
            else if (rbUsuario.Checked)
            {
                frmUsuario usuarios = new frmUsuario();
                usuarios.ShowDialog();
            }
        }
    }
}
