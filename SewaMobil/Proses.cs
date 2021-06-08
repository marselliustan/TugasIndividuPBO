using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewaMobil
{
    class Proses
    {
        public static int inputPilihan()
        {
            Console.Write("Masukkan pilihan (1-2): ");
            int pil = Convert.ToInt32(Console.ReadLine());
            return pil;
        }
        public static string inputPilihanMobil()
        {
            Console.Write("Masukkan pilihan (nama mobil): ");
            string pilMobil = Console.ReadLine().ToLower();
            return pilMobil;
        }
        public static int inputPilihanPaket()
        {
            Console.Write("Masukkan pilihan (1-3): ");
            int pilPaket = Convert.ToInt32(Console.ReadLine());
            return pilPaket;
        }
        public static string ulangiAplikasi()
        {
            Console.Write("Kembali ke beranda? [y/n]: ");
            string ulang = Console.ReadLine().ToLower();
            return ulang;
        }
    }
}
