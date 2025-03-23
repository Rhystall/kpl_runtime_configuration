using System;
using System.IO;
using Newtonsoft.Json;

public class CovidConfig
{
    public string SatuanSuhu { get; set; }
    public int BatasHariDeman { get; set; }
    public string PesanDitolak { get; set; }
    public string PesanDiterima { get; set; }

    private const string ConfigFile = "covid_config.json";

    public CovidConfig()
    {
        LoadConfig();
    }

    private void LoadConfig()
    {
        if (File.Exists(ConfigFile))
        {
            string json = File.ReadAllText(ConfigFile);
            var config = JsonConvert.DeserializeObject<CovidConfig>(json);

            SatuanSuhu = config.SatuanSuhu;
            BatasHariDeman = config.BatasHariDeman;
            PesanDitolak = config.PesanDitolak;
            PesanDiterima = config.PesanDiterima;
        }
        else
        {
            // Gunakan nilai default
            SatuanSuhu = "celcius";
            BatasHariDeman = 14;
            PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

            SaveConfig(); // Simpan konfigurasi default ke file
        }
    }

    public void SaveConfig()
    {
        var json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(ConfigFile, json);
    }

    public void UbahSatuan()
    {
        SatuanSuhu = (SatuanSuhu == "celcius") ? "fahrenheit" : "celcius";
        SaveConfig();
    }
}
