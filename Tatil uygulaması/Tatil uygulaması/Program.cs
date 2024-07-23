using System;

class Program
{
    static void Main()
    {
        bool devamEdilsin = true;

        while (devamEdilsin)
        {
            Console.WriteLine("Hoş geldiniz! Tatil planlamak için size nasıl yardımcı olabilirim?");
            Console.WriteLine("Lütfen aşağıdaki lokasyonlardan birini seçiniz:");
            Console.WriteLine("1 - Bodrum (Paket başlangıç fiyatı 4000 TL)");
            Console.WriteLine("2 - Marmaris (Paket başlangıç fiyatı 3000 TL)");
            Console.WriteLine("3 - Çeşme (Paket başlangıç fiyatı 5000 TL)");

            string secilenLokasyon = LokasyonSec();
            int kisiSayisi = KisiSayisiAl();

            Console.WriteLine($"\n{LokasyonBilgisi(secilenLokasyon)} ");


            Console.WriteLine("1 - Kara yolu (Kişi başı ulaşım tutarı gidiş-dönüş 1500 TL)");
            Console.WriteLine("2 - Hava yolu (Kişi başı ulaşım tutarı gidiş-dönüş 4000 TL)");
            Console.WriteLine("\nLütfen yukardaki ulaşım seçeneklerinden birini seçiniz:");

            int secilenUlasim = UlasimSec();

            int toplamMaliyet = ToplamMaliyetHesapla(secilenLokasyon, kisiSayisi, secilenUlasim);

            if (toplamMaliyet > 0)
            {
                Console.WriteLine($"\nToplam tatil maliyeti: {toplamMaliyet} TL");
            }
            else
            {
                Console.WriteLine("\nMaliyet hesaplanamadı.");
            }

            Console.Write("\nBaşka bir tatil planlamak ister misiniz? (evet/hayır): ");
            string cevap = Console.ReadLine().ToLower();

            if (cevap == "evet")
            {
                devamEdilsin = true;
            }
            else if (cevap != "evet")
            {
                Console.WriteLine("iyi günler!");
                devamEdilsin = false;
            }
            else
            {
                Console.WriteLine("Geçersiz yanıt! ");
                devamEdilsin = false;
            }
        }

    }

    static string LokasyonSec()
    {
        string[] lokasyonlar = { "Bodrum", "Marmaris", "Çeşme" };

        while (true)
        {
            Console.Write("Lokasyon seçiminizi yapınız (1-3): ");
            int secim;
            if (int.TryParse(Console.ReadLine(), out secim) && secim >= 1 && secim <= 3)
            {
                return lokasyonlar[secim - 1];
            }
            else
            {
                Console.WriteLine("Hatalı giriş! Lütfen geçerli bir lokasyon numarası seçiniz.");
            }
        }
    }

    static int KisiSayisiAl()
    {
        while (true)
        {
            Console.Write("Kaç kişi için tatil planlamak istiyorsunuz? ");
            int kisiSayisi;
            if (int.TryParse(Console.ReadLine(), out kisiSayisi) && kisiSayisi > 0)
            {
                return kisiSayisi;
            }
            else
            {
                Console.WriteLine("Hatalı giriş! Lütfen geçerli bir kişi sayısı giriniz.");
            }
        }
    }

    static int UlasimSec()
    {
        while (true)
        {
            Console.Write("Ulaşım seçiminizi yapınız (1-2): ");
            int secim;
            if (int.TryParse(Console.ReadLine(), out secim) && (secim == 1 || secim == 2))
            {
                return secim;
            }
            else
            {
                Console.WriteLine("Hatalı giriş! Lütfen geçerli bir ulaşım seçeneği numarası seçiniz.");
            }
        }
    }

    static int ToplamMaliyetHesapla(string secilenLokasyon, int kisiSayisi, int secilenUlasim)
    {
        int baslangicFiyat = 0;

        switch (secilenLokasyon.ToLower())
        {
            case "bodrum":
                baslangicFiyat = 4000;
                break;
            case "marmaris":
                baslangicFiyat = 3000;
                break;
            case "çeşme":
                baslangicFiyat = 5000;
                break;
            default:
                Console.WriteLine("Hatalı lokasyon bilgisi!");
                return 0; // Geçersiz lokasyon durumunda 0 döndür
        }

        int ulasimTutari = (secilenUlasim == 1) ? 1500 : 4000;

        return (baslangicFiyat + ulasimTutari) * kisiSayisi;
    }

    static string LokasyonBilgisi(string secilenLokasyon)
    {
        switch (secilenLokasyon.ToLower())
        {
            case "bodrum":
                return "Bodrum'da denize girebilir, tarihi yerleri ziyaret edebilirsiniz.";
            case "marmaris":
                return "Marmaris'te deniz turu yapabilir, gece hayatını keşfedebilirsiniz.";
            case "çeşme":
                return "Çeşme'de plaj keyfi yapabilir, rüzgar sörfü deneyebilirsiniz.";
            default:
                return "Belirtilen lokasyonda tatil yapma seçeneği hakkında bilgi bulunamadı.";
        }
    }
}