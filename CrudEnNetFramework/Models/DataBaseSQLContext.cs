using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEnNetFramework.Models
{
    internal class DataBaseSQLContext
    {
        public SqlConnection conn { get; }
        public  DataBaseSQLContext()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-5NSPV0V";
            builder.InitialCatalog = "CRUD";
            builder.UserID = "sa";
            builder.Password = "123456";

            conn = new SqlConnection(builder.ConnectionString);
         
        }
    }
}
