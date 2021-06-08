using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewaMobil
{
    class AksesDatabase
    {
        public static void tambahData()
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Tambah Mobil");
                Console.WriteLine("====================");
                Console.Write("Nama          : ");
                string nama = Console.ReadLine().ToLower();
                Console.Write("jumlah kursi  : ");
                int kursi = Convert.ToInt32(Console.ReadLine());
                Console.Write("stock         : ");
                int stok = Convert.ToInt32(Console.ReadLine());
                if (nama != "" && kursi != 0 && stok != 0)
                {
                    bool verif = cekData(nama, 0);
                    if (verif == true)
                    {
                        using (var context = new MobilModel())
                        {
                            var result = context.Mobils.SingleOrDefault(k => k.namaMobil == nama);
                            if (result != null)
                            {
                                result.jumlahKursi = kursi;
                                result.stock = stok;
                                context.SaveChanges();
                                Console.WriteLine("- Mobil sudah ada di database dan berhasil diupdate -");
                            }
                        }
                    }
                    else
                    {
                        using (var context = new MobilModel())
                        {
                            var newMobil = new Mobil
                            {
                                namaMobil = nama,
                                jumlahKursi = kursi,
                                stock = stok
                            };
                            context.Mobils.Add(newMobil);
                            context.SaveChanges();
                            Console.WriteLine("== BERHASIL ==");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("- Nama, jumlah kursi, dan stok tidak boleh kosong -");
                    tambahData();
                }
            }
            catch
            {
                Console.WriteLine("- Pastikan telah mengisi dengan benar -");
                tambahData();
            }
            
        }

        public static bool tampilData(int kursi)
        {
            Console.WriteLine("");
            Console.WriteLine("List Mobil");
            Console.WriteLine("====================");
            Console.WriteLine("Mobil\tKursi\tStok");
            using (var context = new MobilModel())
            {
                var query = from mobil in context.Mobils where mobil.jumlahKursi>=kursi select mobil;
                List<Mobil> listMobil = query.ToList<Mobil>();
                if(listMobil.Count == 0)
                {
                    return false;
                }
                else
                {
                    foreach (var item in listMobil)
                    {
                        Console.WriteLine(item.namaMobil + "\t" + item.jumlahKursi + "\t" + item.stock);
                    }
                    return true;
                }

            }
        }

        public static bool cekData(string nama, int kursi)
        {
            using (var context = new MobilModel())
            {
                var query = from mobil in context.Mobils where mobil.jumlahKursi >= kursi select mobil;
                foreach (var item in query)
                {
                    if(item.namaMobil == nama)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static void updateStok(string nama)
        {
            using (var context = new MobilModel())
            {
                var result = context.Mobils.SingleOrDefault(k => k.namaMobil == nama);
                if (result != null)
                {
                    result.stock = result.stock - 1;
                    context.SaveChanges();
                    if (result.stock == 0)
                    {
                        hapusMobil(nama);
                    }
                }
            }
        }

        public static void hapusMobil(string nama)
        {
            using (var context = new MobilModel())
            {
                context.Mobils.RemoveRange(context.Mobils.Where(item => item.namaMobil == nama));
                context.SaveChanges();
            }
        }

        
    }
}
