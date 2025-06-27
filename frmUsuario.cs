using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace PryCepedaIEFI
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        //conexion
        ClsConexion conexion = new ClsConexion();

        //cargar datos en el dgv cuando se abre el formulario
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            string query = "select * from Contactos";
            SqlDataAdapter AD = new SqlDataAdapter(query, conexion.Conectar());
            DataTable Dt = new DataTable();
            AD.Fill(Dt);
            dgvListado.DataSource = Dt;

        }

        //muestro datos en el txt al hacer click
        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoUsuario.Text = dgvListado.SelectedCells[0].Value.ToString();
            txtNombreUsuario.Text = dgvListado.SelectedCells[1].Value.ToString();
            txtDni.Text = dgvListado.SelectedCells[2].Value.ToString();
            txtDireccion.Text = dgvListado.SelectedCells[3].Value.ToString();
            txtContraseñaUsuario.Text = dgvListado.SelectedCells[4].Value.ToString();
            txtTelefono.Text = dgvListado.SelectedCells[5].Value.ToString();
        }

        //agrego usuarios
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string query = "INSERT INTO Productos Values('" + txtCodigoUsuario.Text + "','" + txtNombreUsuario.Text + "','" + txtDni.Text + "','" + txtDireccion.Text + "','" + txtContraseñaUsuario.Text + "','" + txtTelefono.Text + "')";
            SqlCommand comando = new SqlCommand(query, conexion.Conectar());
            comando.ExecuteNonQuery();
            MessageBox.Show("¡¡Registro Agregado!!");
        }

        //elimino usuarios
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string query = "DELETE FROM Contactos WHERE CodigoUS = @CodigoUS ";
            SqlCommand comando = new SqlCommand(query, conexion.Conectar());
            comando.Parameters.AddWithValue("@CodigoUS", txtCodigoUsuario);
            comando.ExecuteNonQuery();
            MessageBox.Show("Producto Eliminado! :( ");
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string query = "UPDATE FROM set CodigoUS=" + txtCodigoUsuario.Text + ",Nombre= '" + txtNombreUsuario.Text + "',Dni= '" + txtDni.Text + "' ,Direccion= '" + txtDireccion.Text + "' Contraseña= '" + txtContraseñaUsuario.Text + "' Telefono= '" + txtTelefono.Text + "' where CodigoUS=" + txtCodigoUsuario.Text + "";
            SqlCommand comando = new SqlCommand(query, conexion.Conectar());
            int cantidad;
            cantidad = comando.ExecuteNonQuery();
            if (cantidad > 0)
            {
                MessageBox.Show("Registro Modificado");
            }
        }

        private void frmUsuario_Load_1(object sender, EventArgs e)
        {

        }
    }
}
