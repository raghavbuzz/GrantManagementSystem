using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrantManagementApi.Models
{
    public class GrantManagementContext
    {
        public string ConnectionString { get; set; }

        public GrantManagementContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }


        public List<DbTest> GetAllDbTest()
        {
            List<DbTest> list = new List<DbTest>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from DbTest", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DbTest()
                        {
                            idDbTest = Convert.ToInt32(reader["idDbTest"]),
                            Name = reader["Name"].ToString()                           
                        });
                    }
                }
            }
            return list;
        }

    }
}
