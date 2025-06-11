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
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        //conexion
        ClsConexion conexion = new ClsConexion();
        
        //cargo datos en el dgv cuando se abre el formulario
        private void frmStock_Load(object sender, EventArgs e)
        {
            string query = "select * from Productos";
            SqlDataAdapter AD = new SqlDataAdapter(query, conexion.Conectar());
            DataTable Dt = new DataTable();
            AD.Fill(Dt);
            dgvStock.DataSource = Dt;
        }

        //muestro datos al hacer click en una fila
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgvStock.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvStock.SelectedCells[1].Value.ToString();
            txtDescripcion.Text = dgvStock.SelectedCells[2].Value.ToString();
            txtPrecio.Text = dgvStock.SelectedCells[3].Value.ToString();
            txtStock.Text = dgvStock.SelectedCells[4].Value.ToString();
            txtCategoria.Text = dgvStock.SelectedCells[5].Value.ToString();
        }

        //agrego prodcutos al hacer click en el boton Agregar
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string query = "INSERT INTO Productos Values('" + txtCodigo.Text + "','" + txtNombre.Text + "','" + txtDescripcion.Text + "','" + txtPrecio.Text + "','" + txtStock.Text + "','" + txtCategoria.Text + "')";
            SqlCommand comando = new SqlCommand(query, conexion.Conectar());
            comando.ExecuteNonQuery();
            MessageBox.Show("¡Registro Agregado!");
        }

        //elimino productos al hacer click en el boton eliminar
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string query = "DELETE FROM Productos WHERE Codigo = @Codigo ";
            SqlCommand comando = new SqlCommand(query, conexion.Conectar());
            comando.Parameters.AddWithValue("@Codigo", txtCodigo);
            comando.ExecuteNonQuery();
            MessageBox.Show("¡Producto Eliminado!");
        }
    }
}
