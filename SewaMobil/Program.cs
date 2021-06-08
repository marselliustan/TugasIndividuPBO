using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewaMobil
{
    class Program
    {
        static void Main(string[] args)
        {
            awal:
            Console.WriteLine("Selamat Datang");
            Console.WriteLine("====================");
            Console.WriteLine("1. Saya ingin menyewa mobil");
            Console.WriteLine("2. Saya admin");
            int pil = Proses.inputPilihan();

            if (pil == 2)
            {
                Admin.login();
                string ulangi = Proses.ulangiAplikasi();
                if (ulangi == "y")
                {
                    Console.Clear();
                    goto awal;
                }
                else if (ulangi == "n")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("- Pilihan tidak valid -");
                    Proses.ulangiAplikasi();
                }
            }
            else if (pil == 1)
            {
                Console.Write("Masukkan jumlah kursi yang diinginkan: ");
                int kursi = Convert.ToInt32(Console.ReadLine());

                //Pilih mobil
                bool verifMobil = AksesDatabase.tampilData(kursi);
                if(verifMobil == false)
                {
                    Console.WriteLine("- Tidak ada mobil yang cocok -");
                    string ulangi = Proses.ulangiAplikasi();
                    if (ulangi == "y")
                    {
                        Console.Clear();
                        goto awal;
                    }
                    else if (ulangi == "n")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("- Pilihan tidak valid -");
                        Proses.ulangiAplikasi();
                    }
                }
                string pilMobil = Proses.inputPilihanMobil();
                bool verif = AksesDatabase.cekData(pilMobil, kursi);
                if (verif == false)
                {
                    Console.WriteLine("- Mobil tidak valid -");
                    Proses.inputPilihanMobil();
                }

                //Pilih paket
                Paket.tampilPaket();
                int pilPaket = Proses.inputPilihanPaket();
                while (pilPaket > 3 || pilPaket <= 0)
                {
                    Console.WriteLine("- Paket tidak valid -");
                    pilPaket = Proses.inputPilihanPaket();
                }
                Console.Write("Masukkan jumlah paket: ");
                int jlhPaket = Convert.ToInt32(Console.ReadLine());

                //Buat pesanan
                Pesanan pesanan = new Pesanan();
                int hargaTotal = pesanan.buatPesanan(pilPaket, jlhPaket);
                Pembayaran.bayar(hargaTotal, pilMobil);

                //Ulangi Aplikasi
                string ulang = Proses.ulangiAplikasi();
                if (ulang == "y")
                {
                    Console.Clear();
                    goto awal;
                }
                else if(ulang == "n")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("- Pilihan tidak valid -");
                    Proses.ulangiAplikasi();
                }
            }
            else
            {
                Console.WriteLine("- Pilihan tidak valid -");
                Proses.inputPilihan();
            }
        }
    }
}
