namespace Odev_Rastgele_Sayi_Siralama
{
    internal class Program
    {
        static int sayi_girdi;

        static int[] sayilar = new int[10];

        static int en_buyuk;

        static int en_kucuk;
        static void Main(string[] args)
        {

            Random rnd = new Random();

            int sayi_1;

            int sayi_2;

            Console.Write("Rastgele oluşturulacak sayıların başlangıç ve bitiş noktalarını giriniz.\n\nBaşlangıç noktası: ");

            SayiKontrol(ref sayi_girdi);

            sayi_1 = sayi_girdi;

            Console.WriteLine("Bitiş noktası (Başlangıç noktasından küçük bir değer girmeniz halinde yeni başlangıç noktası kabul edilecektir.):");

            SayiKontrol(ref sayi_girdi);

            sayi_2 = sayi_girdi;

            while (true)
            {
                if (sayi_1 == sayi_2)
                {
                    Console.Write("Hatalı giriş. Sayıların birbirinden farklı olduğuna emin olun ve tekrar deneyin: ");

                    SayiKontrol(ref sayi_girdi);

                    sayi_2 = sayi_girdi;
                }
                else
                {
                    break;
                }
            }

            if (sayi_1 < sayi_2)
            {
                for (int i = 0; i < sayilar.Length; i++)
                {
                    sayilar[i] = rnd.Next(sayi_1, sayi_2);
                }
            }
            else
            {
                for (int i = 0; i < sayilar.Length; i++)
                {
                    sayilar[i] = rnd.Next(sayi_2, sayi_1);
                }
            }

            Console.WriteLine("Rastgele oluşturulan diziniz:\n");

            DiziYazdir();

            EnBuyukDeger();

            EnKucukDeger();

            Console.WriteLine("En büyük değer: " + en_buyuk);

            Console.WriteLine("En küçük değer: " + en_kucuk);


        }

        static void SayiKontrol(ref int sayi_girdi)
        {
            while (true)
            {
                try
                {
                    sayi_girdi = Convert.ToInt32(Console.ReadLine());

                    if (sayi_girdi <= 0)
                    {
                        Console.Write("Sayınızın pozitif olduğuna emin olun ve tekrar deneyin: ");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.Write("Hatalı giriş. Lütfen sayınızı rakam formatında tekrar girin: ");
                }
                catch (OverflowException)
                {
                    Console.Write("Sayı değeri çok büyük. Sayıyı 10 hanenin altında tutarak tekrar deneyin: ");
                }
            }
        }

        static void DiziYazdir()
        {
            foreach (int item in sayilar)
            {
                Console.WriteLine(item);
            }
        }

        static void EnBuyukDeger()
        {
            for (int i = 1; i < sayilar.Length; i++)
            {
                if (sayilar[i] > sayilar[i - 1])
                {
                    en_buyuk = sayilar[i];
                }
            }
        }
        static void EnKucukDeger()
        {
            for (int i = 0; i < sayilar.Length; i++)
            {
                if (i < sayilar.Length - 1)
                {
                    if (sayilar[i] < sayilar[i + 1])
                    {
                        en_kucuk = sayilar[i];
                    }
                }
                else if (i == sayilar.Length)
                {
                    if (sayilar[i] < sayilar[i - 1])
                    {
                        en_kucuk = sayilar[i];
                    }
                }
            }
        }
    }
}
