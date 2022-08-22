using ProyectoFinal.MODEL;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
        public static class ProductoHandler
        {
            public const string ConnectionString =
               "Server=DESKTOP-S9C9GN7;Database=SistemaGestion;Trusted_Conection=true";

        public static List<Producto> GetProductos()
            {
                List<Producto> productsList = new List<Producto>();
                string query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto";

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            Producto objProducto = new Producto();
                            objProducto.Id = Convert.ToInt32(sqlDataReader["Id"]);
                            objProducto.Descripciones = sqlDataReader["Descripciones"].ToString();
                            objProducto.Costo = Convert.ToDouble(sqlDataReader["Costo"]);
                            objProducto.PrecioVenta = Convert.ToDouble(sqlDataReader["PrecioVenta"]);
                            objProducto.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                            objProducto.IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]);
                            productsList.Add(objProducto);
                        }
                        sqlDataReader.Close();
                        sqlConnection.Close();
                    }

                    catch (Exception ex)
                    {

                        throw new Exception("There is an error on query definition! " + ex.Message);
                    }
                }
                return productsList;
            }


            public static bool EliminarProducto(int Id)
            {
                bool result = false;
                string query = "DELETE FROM Producto " +
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


            public static bool CrearProducto(Producto producto)
            {
                bool result = false;
                string query = "INSERT INTO Producto" +
                    "(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" +
                    "VALUES (@descripciones, @costo, @precioVenta, @stock, 1)";

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                    sqlCommand.Parameters.AddWithValue("@costo", producto.Costo);
                    sqlCommand.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                    sqlCommand.Parameters.AddWithValue("@stock", producto.Stock);

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


            public static bool ModificarProducto(Producto producto)
            {
                string query = "UPDATE Producto " +
                    "SET Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock " +
                    "WHERE Id = @id";

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    bool result = false;
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@id", producto.Id);
                    sqlCommand.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                    sqlCommand.Parameters.AddWithValue("@costo", producto.Costo);
                    sqlCommand.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                    sqlCommand.Parameters.AddWithValue("@stock", producto.Stock);

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

