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


namespace PryCepedaIEFI
{ 
internal class ClsConexion
{
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
