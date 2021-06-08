using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SewaMobil
{
    class Pembayaran
    {
        public static void bayar(int hargaTotal, string namaMobil)
        {
            int kembalian;
            Console.WriteLine("");
            Console.WriteLine("Pembayaran");
            Console.WriteLine("====================");
            try
            {
                Console.Write("Masukkan jumlah uang: ");
                int uangBayar = Convert.ToInt32(Console.ReadLine());

                if (uangBayar >= hargaTotal)
                {
                    kembalian = uangBayar - hargaTotal;
                    Console.WriteLine("Kembalian   : Rp.{0},00", kembalian);
                    string konfirmasi = konfirmasiPembayaran();
                    if (konfirmasi == "y")
                    {
                        AksesDatabase.updateStok(namaMobil);
                        using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\Log.txt"))
                        {
                            sw.WriteLine("Tanggal pesan   : " + DateTime.Now);
                            sw.WriteLine("== BERHASIL ==");
                            sw.Close();
                        }
                        Console.WriteLine("== BERHASIL ==");
                    }
                    else if (konfirmasi == "n")
                    {
                        using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\Log.txt"))
                        {
                            sw.WriteLine("Tanggal pesan   : " + DateTime.Now);
                            sw.WriteLine("== BATAL ==");
                            sw.Close();
                        }
                        Console.WriteLine("== PESANAN DIBATALKAN ==");
                    }
                    else
                    {
                        Console.WriteLine("- Pilihan tidak valid -");
                        konfirmasiPembayaran();
                    }
                }
                else
                {
                    Console.WriteLine("- Uang tidak valid atau tidak cukup -");
                    bayar(hargaTotal, namaMobil);
                }
            }
            catch
            {
                Console.WriteLine("- Uang tidak valid -");
                bayar(hargaTotal, namaMobil);
            }
        }

        private static string konfirmasiPembayaran()
        {
            Console.Write("Konfirmasi pembayaran [y/n]: ");
            string pil = Console.ReadLine().ToLower();
            return pil;
        }
    }
}
