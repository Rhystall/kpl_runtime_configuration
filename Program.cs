using System;

class Program
{
    static void Main()
    {
        CovidConfig config = new CovidConfig();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDeman = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = (config.SatuanSuhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
                         (config.SatuanSuhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5);

        bool hariDemanValid = hariDeman < config.BatasHariDeman;

        Console.WriteLine(suhuValid && hariDemanValid ? config.PesanDiterima : config.PesanDitolak);

        // Ubah satuan suhu dan simpan konfigurasi baru
        Console.WriteLine("\nApakah ingin mengubah satuan suhu? (y/n)");
        string pilihan = Console.ReadLine().ToLower();
        if (pilihan == "y")
        {
            config.UbahSatuan();
            Console.WriteLine($"Satuan suhu diubah menjadi: {config.SatuanSuhu}");
        }
    }
}
