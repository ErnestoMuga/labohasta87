using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.AccesoDatos.Core
{
    public class UsuarioDA
    {
        public Usuario BuscarUsuarioPorId(int id)
        {
            Usuario SegSSOMUsuario = null;
            using (SqlConnection conexion = new
           SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {

                using (SqlCommand comando = new
                SqlCommand("paUsuario_BuscaPorId", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", id);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        SegSSOMUsuario = LlenarEntidad(reader);

                    }

                    conexion.Close();
                }
            }
            return SegSSOMUsuario;
        }

        public List<Usuario> ListaUsuarios()
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;
            using (SqlConnection conexion = new
            SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuarioLista",
            conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }


        public Usuario LlenarEntidad(IDataReader reader)
        {
            Usuario usuario = new Usuario();
            reader.GetSchemaTable().DefaultView.RowFilter =
            "ColumnName='IdUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdUsuario"]))
                    usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Clave'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Clave"]))
                    usuario.Clave = (byte[])reader["Clave"];
            }
            reader.GetSchemaTable().DefaultView.RowFilter =
            "ColumnName='CodUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["CodUsuario"]))
                    usuario.CodUsuario = Convert.ToString(reader["CodUsuario"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Nombres"]))
                    usuario.Nombres = Convert.ToString(reader["Nombres"]);
            }
            return usuario;
        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    ConfigurationManager.AppSettings["cnnSql"]
                ].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand(
                    "paUsuarioInsertar",
                    conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "@CodUsuario",
                        usuario.CodUsuario);

                    comando.Parameters.AddWithValue(
                        "@Clave",
                        usuario.Clave);

                    comando.Parameters.AddWithValue(
                        "@Nombres",
                        usuario.Nombres);

                    conexion.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ModificarUsuario(Usuario usuario, bool cambiarClave)
        {
            using (SqlConnection conexion = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    ConfigurationManager.AppSettings["cnnSql"]
                ].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand(
                    "paUsuarioModificar",
                    conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "@IdUsuario",
                        usuario.IdUsuario);

                    comando.Parameters.AddWithValue(
                        "@CodUsuario",
                        usuario.CodUsuario);

                    comando.Parameters.AddWithValue(
                        "@Nombres",
                        usuario.Nombres);

                    if (cambiarClave)
                    {
                        comando.Parameters.AddWithValue(
                            "@Clave",
                            usuario.Clave);
                    }
                    else
                    {
                        comando.Parameters.Add(
                            "@Clave",
                            SqlDbType.VarBinary,
                            -1).Value = DBNull.Value;
                    }

                    comando.Parameters.AddWithValue(
                        "@CambiarClave",
                        cambiarClave);

                    conexion.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (SqlConnection conexion = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    ConfigurationManager.AppSettings["cnnSql"]
                ].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand(
                    "paUsuarioEliminar",
                    conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);

                    conexion.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        public Usuario BuscarUsuario(Usuario usuario)
        {
            Usuario SegSSOMUsuario = null;
            using (SqlConnection conexion = new
           SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {

                using (SqlCommand comando = new
                SqlCommand("paUsuario_BuscaCodUserClave", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure; comando.Parameters.AddWithValue("@Clave", usuario.Clave);
                    comando.Parameters.AddWithValue("@CodUsuario",usuario.CodUsuario);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        SegSSOMUsuario = LlenarEntidad(reader);

                    }

                    conexion.Close();
                }
            }
            return SegSSOMUsuario;
        }
    }
}
