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
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        //conexion
        ClsConexion conexion = new ClsConexion();

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            string usuario, contraseña;
            usuario = txtUsuario.Text;
            contraseña = txtContraseña.Text;
            if(usuario == "Lucas" && contraseña == "Lucascepeda10")
            {
                frmMenu menu = new frmMenu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Te equivocaste pa!", "Datos erroneos",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {

            if (conexion.Conectar().State == ConnectionState.Open)
            {
                MessageBox.Show("¡Conectado correctamente!");
            }

        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }
    }
}
