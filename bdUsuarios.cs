using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace PryCepedaIEFI
{
    internal class bdUsuarios
    {
        private OleDbConnection conexion;
        private OleDbCommand comando;

        private String cadena;

        public bdUsuarios()
        {
            cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=usuarios.accdb;";
            conexion = new OleDbConnection(cadena);
            comando = new OleDbCommand();
        }

        public void Conectar()
        {
            if (conexion.State != System.Data.ConnectionState.Open)
            {
                conexion.Open();
                comando.Connection = conexion;

            }
        }
        public void Desconectar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
        public bool UsuarioExiste(string nombreUsuario)
        {
            try
            {
                Conectar();
                comando.CommandText = "SELECT COUNT(*) FROM usuarios WHERE NombreUsuarios = @NombreUsuarios";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@NombreUsuarios", nombreUsuario);
                int count = (int)comando.ExecuteScalar();
                return count > 0;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Error al verificar el usuario: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Desconectar();
            }

        }
        public bool InsertarUsuario(string nombreUsuario, string contraseña)
        {
            try
            {
                Conectar();
                comando.CommandText = "INSERT INTO usuarios (NombreUsuarios, Contraseña) VALUES (@NombreUsuarios, @Contraseña)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@NombreUsuarios", nombreUsuario);
                comando.Parameters.AddWithValue("@Contraseña", contraseña);
                int filas = comando.ExecuteNonQuery();
                return filas > 0;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Error al insertar el usuario: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;



            }
            finally
            {
                Desconectar();
            }


        }







    }
}

