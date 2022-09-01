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
            builder.DataSource = "";
            builder.InitialCatalog = "";
            builder.UserID = "";
            builder.Password = "";

            conn = new SqlConnection(builder.ConnectionString);
         
        }
    }
}
