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
       
       /* public List<CarsInfo> ci()
        {
            List<CarsInfo> carInfo = new List<CarsInfo>();
            SqlCommand cmd;
            SqlConnection con;
            con = new SqlConnection(_connectionString);
            con.Open();
            cmd = new SqlCommand("Select * from Masini", con);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
               
                while (rdr.Read())
                {
                    
                    CarsInfo c = new CarsInfo();
                    c.id = Convert.ToInt32(rdr[0]);
                    c.Marca = rdr.GetString(1);
                    c.Capacitate = rdr.GetString(2);
                    c.Km = rdr.GetString(3);
                    c.Pret = rdr.GetString(4);
                    c.Combustibil = rdr.GetString(5);
                    c.An = rdr.GetString(6);
                    c.Descriere = rdr.GetString(7);
                    c.CodSasiu = rdr.GetString(8);
                    carInfo.Add(c);

                }
                con.Close();
            }
            return carInfo;
            
        }*/
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
