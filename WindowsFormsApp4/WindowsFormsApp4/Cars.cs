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
      
        public Int32 Id { get; set; }
        public string Marca { get; set; }
        public string Capacitate { get; set; }
        public string Combustibil { get; set; }
        public string Descriere { get; set; }
        public string An { get; set; }
        public string Pret { get; set; }
        public string Km { get; set; }
        public string CodSasiu { get; set; }

    }
   
}
