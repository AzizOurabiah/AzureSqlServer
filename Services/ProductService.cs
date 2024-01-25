using System.Data.SqlClient;

namespace WepAppVisualStudio.Services
{
    public class ProductService
    {
        private static string db_source = "firstserveraziz.database.windows.net";
        private static string db_user = "sqlserver";
        private static string db_password = "Admin.123456789";
        private static string db_database = "sqlserver";


        private SqlConnection Connection()
        {
            var _builder = new SqlConnectionStringBuilder();

            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);
        }
    }
}
