using ProyectoFinal.MODEL;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public static class VentaHandler
    {
        public const string ConnectionString =
            "Data Source=YUXMED0040L;Initial Catalog=SystemManagement;User=admin;Password=admin";

        public static List<Venta> GetVentas()
        {
            List<Venta> salesList = new List<Venta>();
            string query = "SELECT Id, Comentarios FROM Venta";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Venta objSales = new Venta();
                        objSales.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        objSales.Comentarios = sqlDataReader["Comentarios"].ToString();
                        salesList.Add(objSales);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }

            return salesList;
        }

        public static bool EliminarVenta(int Id)
        {
            bool result = false;
            string query = "DELETE FROM Venta " +
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

        public static bool CrearVenta(Venta venta)
        {
            bool result = false;
            string query = "INSERT INTO Venta" +
                "(Comentarios)" +
                "VALUES (@comentarios)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@comentarios", venta.Comentarios);

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

        public static bool ModificarVenta(Venta venta)
        {
            string query = "UPDATE Venta " +
                "SET Comentarios = @comentarios " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                bool result = false;
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", venta.Id);
                sqlCommand.Parameters.AddWithValue("@comentarios", venta.Comentarios);

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
