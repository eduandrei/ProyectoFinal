using ProyectoFinal.MODEL;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public static class UsuarioHandler
    {
        public const string ConnectionString =
            "Data Source=YUXMED0040L;Initial Catalog=SystemManagement;User=admin;Password=admin";

        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> userList = new List<Usuario>();

            string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Usuario objUsuario = new Usuario();
                        objUsuario.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        objUsuario.Nombre = sqlDataReader["Nombre"].ToString();
                        objUsuario.Apellido = sqlDataReader["Apellido"].ToString();
                        objUsuario.NombreUsuario = sqlDataReader["NombreUsuario"].ToString();
                        objUsuario.Contrasena = sqlDataReader["Contraseña"].ToString();
                        objUsuario.Mail = sqlDataReader["Mail"].ToString();
                        userList.Add(objUsuario);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }
            return userList;
        }


        public static bool EliminarUsuario(int Id)
        {
            bool result = false;
            string query = "DELETE FROM Usuario " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);

                try
                {
                    sqlConnection.Open();
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        result = true;
                    }
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
                return result;
            }
        }


        public static bool CrearUsuario(Usuario usuario)
        {
            bool result = false;
            string query = "INSERT INTO Usuario" +
                "(Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                "VALUES (@nombre, @apellido, @nombreUsuario, @contrasena, @mail)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nombre", usuario.Nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", usuario.Apellido);
                sqlCommand.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                sqlCommand.Parameters.AddWithValue("@mail", usuario.Mail);

                try
                {
                    sqlConnection.Open();
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        result = true;
                    }
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
                return result;
            }
        }


        public static bool ModificarUsuario(Usuario usuario)
        {
            string query = "UPDATE Usuario " +
                "SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contraseña = @contrasena, Mail = @mail " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                bool result = false;
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", usuario.Id);
                sqlCommand.Parameters.AddWithValue("@nombre", usuario.Nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", usuario.Apellido);
                sqlCommand.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                sqlCommand.Parameters.AddWithValue("@mail", usuario.Mail);

                try
                {
                    sqlConnection.Open();
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        result = true;
                    }
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
                return result;
            }
        }
    }
}
