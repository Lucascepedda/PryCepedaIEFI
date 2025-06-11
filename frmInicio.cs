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
            string query = "select * from Contactos where Nombre='" + txtUsuario.Text + "'and Contraseña='" + txtContraseña.Text + "'";

            SqlCommand Comando = new SqlCommand(query, conexion.Conectar());
            SqlDataReader lector;
            lector = Comando.ExecuteReader();

            if (lector.HasRows == true)
            {
                MessageBox.Show("bienvenido");
                Form Formulario = new frmMenu();
                Formulario.Show();


            }
            else
            {
                MessageBox.Show("usuario o contraseña incorrectos");
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
