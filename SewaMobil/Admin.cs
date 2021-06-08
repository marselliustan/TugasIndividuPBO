using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewaMobil
{
    class Admin: User
    {
        public static void login()
        {
            Console.WriteLine("");
            Console.WriteLine("Login");
            Console.WriteLine("====================");
            Console.Write("Masukkan username: ");
            string username = Console.ReadLine().ToLower();
            Console.Write("Masukkan password: ");
            string password = Console.ReadLine();

            if (username == "spongebob" && password == "123")
            {
                halamanAdmin();
            }
            else
            {
                Console.WriteLine("- Username atau password salah -");
                login();
            }
        }

        public static void halamanAdmin()
        {
            Console.WriteLine("");
            Console.WriteLine("Selamat datang admin");
            Console.WriteLine("====================");
            prosesAdmin();
        }

        public static void prosesAdmin()
        {
            Console.WriteLine("1. Tambah data");
            Console.WriteLine("2. Hapus data");
            int pil = Proses.inputPilihan();
            if (pil == 1)
            {
                AksesDatabase.tambahData();
            }
            else if (pil == 2)
            {
                AksesDatabase.tampilData(0);
                string akanDihapus = Proses.inputPilihanMobil();
                bool verif = AksesDatabase.cekData(akanDihapus, 0);
                if (verif == false)
                {
                    Console.WriteLine("- Mobil tidak valid -");
                    Proses.inputPilihanMobil();
                }
                AksesDatabase.hapusMobil(akanDihapus);
                Console.WriteLine("== BERHASIL ==");
            }
            else
            {
                Console.WriteLine("- Pilihan tidak valid -");
                prosesAdmin();
            }
            string ulangi = ulangiProsesAdmin();
            if (ulangi == "y")
            {
                Console.WriteLine("");
                prosesAdmin();
            }
            else if (ulangi == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("- Pilihan tidak valid -");
                ulangiProsesAdmin();
            }

        }

        public static string ulangiProsesAdmin()
        {
            Console.Write("Masih ada? [y/n]: ");
            string ulang = Console.ReadLine().ToLower();
            return ulang;
        }
    }
}
