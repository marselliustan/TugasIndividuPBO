using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewaMobil
{
    class Paket
    {
        public Paket(string namaPaket, int harga)
        {
            this.namaPaket = namaPaket;
            this.hargaPaket = harga;
        }
        public string namaPaket { get; set; }
        public int hargaPaket { get; set; }

        public static void tampilPaket()
        {
            Paket perminggu = new Paket("Weekly", 200000);
            Paket perhari = new Paket("Daily", 250000);
            Paket perjam = new Paket("Hourly", 300000);

            Console.WriteLine("");
            Console.WriteLine("List Paket");
            Console.WriteLine("====================");
            Console.WriteLine(perminggu.namaPaket + "\t:Rp." + perminggu.hargaPaket + ",00");
            Console.WriteLine(perhari.namaPaket + "\t:Rp." + perhari.hargaPaket + ",00");
            Console.WriteLine(perjam.namaPaket + "\t:Rp." + perjam.hargaPaket + ",00");
        }
    }
}
