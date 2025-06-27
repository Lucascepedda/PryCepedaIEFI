using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;


namespace PryCepedaIEFI
{ 
internal class ClsConexion
{
        private readonly string cadenaConexion = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={AppDomain.CurrentDomain.BaseDirectory}Productos1.accdb;";
        private OleDbConnection conexion;
        public clsConexion()
        {
             conexion = new OleDbConnection(cadenaConexion);
        }
        public OleDbConnection ObtenerConexion()
        {
            return conexion;
        }
        public void Abrir()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
        }
        public void Cerrar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }


        }

















































        SqlConnection conexion;

    public SqlConnection Conectar()
    {
        try
        {
            conexion = new SqlConnection("Server=localhost;Initial Catalog=Comercio;Integrated Security=True;Encrypt=False");
            conexion.Open();

            if (conexion.State != ConnectionState.Open)
            {
                MessageBox.Show("¡No conectado!");

            }


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);

        }
        return conexion;
    }
}
}
