using System.Data.SqlClient;
using WepAppVisualStudio.Models;

namespace WepAppVisualStudio.Services
{
    public class ProductService
    {
        private static string db_source = "firstserveraziz.database.windows.net";
        private static string db_user = "sqlserver";
        private static string db_password = "Admin.123456789";
        private static string db_database = "sqlserver";


        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();

            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);
        }
        public List<Product> GetProducts()
        {
            SqlConnection con = GetConnection();

            List<Product> _products_lst = new List<Product>();

            string statement = "select * from Products";

            con.Open();

            SqlCommand cmd = new SqlCommand(statement, con);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    _products_lst.Add(product);
                }
            }
            con.Close();
            return _products_lst;
        }
    }
}
