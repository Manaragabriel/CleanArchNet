using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;

namespace CleanArch_Infrastructure.Database.DapperConnection
{
    internal class DapperCon
    {
        public MySqlConnection connection;
        public DapperCon()
        {
            connection = new MySqlConnection("server=localhost;user=user;password=user;database=clean_arch_ref_database");
            
        }
    }
}
