using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SewaMobil
{
    class Mobil
    {
        [Key]
        public string namaMobil { get; set; }
        public int jumlahKursi { get; set; }
        public int stock { get; set; }
    }
}
