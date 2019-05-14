using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace WindowsFormsApp2
{
    public class PartsInfo
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        public Int32 id { get; set; }
        public string Producator { get; set; }
        public string Pret { get; set; }
        public string Material { get; set; }
        public string Descriere { get; set; }

    }
}
