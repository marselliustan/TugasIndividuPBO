using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SewaMobil
{
    class Pesanan
    {
        int hargaTotal = 0;
        int jlh;
        string namaPaket;
        User penyewa = new User();

        public int buatPesanan(int pilPaket, int n)
        {
            Console.WriteLine("");
            Console.WriteLine("Buat Pesanan");
            Console.WriteLine("====================");
            Console.Write("Masukkan nama           : ");
            penyewa.Nama = Console.ReadLine();
            Console.Write("Masukkan nomor telepon  : ");
            penyewa.NoTelp = Console.ReadLine();
            Console.Write("Masukkan nomor KTP      : ");
            penyewa.NoKtp = Console.ReadLine();

            if (pilPaket == 1)
            {
                namaPaket = "Weekly (mingguan)";
                hargaTotal += 200000 * n;
            }
            else if (pilPaket == 2)
            {
                namaPaket = "Daily (harian)";
                hargaTotal += 250000 * n;
            }
            else if (pilPaket == 3)
            {
                namaPaket = "Hourly (per jam)";
                hargaTotal += 300000 * n;
            }
            jlh = n;
            detailPesanan();
            return hargaTotal;
        }
        public void detailPesanan()
        {
            Console.WriteLine("");
            Console.WriteLine("Detail Pesanan");
            Console.WriteLine("====================");
            Console.WriteLine("Nama          : " + penyewa.Nama);
            Console.WriteLine("Nomor telepon : " + penyewa.NoTelp);
            Console.WriteLine("Nomor KTP     : " + penyewa.NoKtp);
            Console.WriteLine("Paket         : " + namaPaket);
            Console.WriteLine("Jumlah        : " + jlh);
            Console.WriteLine("Harga total   : Rp." + hargaTotal + ",00");
            tulisRiwayat();
        }

        public void tulisRiwayat()
        {
            using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\Log.txt"))
            {
                sw.WriteLine("");
                sw.WriteLine("Nama            : " + Convert.ToString(penyewa.Nama));
                sw.WriteLine("Nomor telepon   : " + Convert.ToString(penyewa.NoTelp));
                sw.WriteLine("Paket           : " + Convert.ToString(namaPaket));
                sw.WriteLine("Harga total     : Rp.{0},00", Convert.ToString(hargaTotal));
                sw.Close();
            }
        }
    }
}
