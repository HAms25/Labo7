using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DProduct
    {
        private readonly string connectionString = "Data Source=LAB1504-27\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=admin;Password=admin";

        public List<Product> Get()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ListarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Name = reader["Name"].ToString(),
                                Price = (decimal)reader["Price"],
                                Stock = (int)reader["Stock"]
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}
