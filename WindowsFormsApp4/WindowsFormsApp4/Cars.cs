using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp4
{
    public class CarsInfo
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
      
        public Int32 id { get; set; }
        public string Marca { get; set; }
        public string Capacitate { get; set; }
        public string Combustibil { get; set; }
        public string Descriere { get; set; }
        public string An { get; set; }
        public string Pret { get; set; }
        public string Km { get; set; }
        public string CodSasiu { get; set; }

    }

    public class CarsData
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        public CarsInfo getData()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * from Masini";
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CarsInfo
                            {
                                id = Convert.ToInt32(reader[0]),
                                Marca = reader[1].ToString(),
                                Capacitate = reader[2].ToString(),
                                Km = reader[3].ToString(),
                                Pret = reader[4].ToString(),
                                Combustibil = reader[5].ToString(),
                                An = reader[6].ToString(),
                                Descriere = reader[7].ToString()
                                
                            };
                        }
                    }
                    return null;
                }

            }
        }
       
        public CarsInfo setData(Int32 a, string b, string c, string d, string e, string f, string g, string h, string i)
        {
            return new CarsInfo
            {
                id = a,
                Marca = b,
                Capacitate = c,
                Km = d,
                Pret = e,
                Combustibil = f,
                An = g,
                Descriere = h,
                CodSasiu = i
            };
        }

    }
}
