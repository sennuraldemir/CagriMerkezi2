using System;

namespace CagriMerkezi2
{
    public class MyStaticVariables
    {
        public const int DegerlendirmeAsamasinda = 1;
        public const int DevamEdiyor = 2;
        public const int Sonuclandi = 3;
    }

    public class Program
    {
        public static void Main()
        {
            // Örnek olarak bir başvuru durumu belirleyelim
            int basvuruDurumu = MyStaticVariables.DevamEdiyor;

            // Başvuru durumunu ekrana yazdırma
            switch (basvuruDurumu)
            {
                case MyStaticVariables.DegerlendirmeAsamasinda:
                    Console.WriteLine("Başvuru değerlendirme aşamasında.");
                    break;
                case MyStaticVariables.DevamEdiyor:
                    Console.WriteLine("Başvuru devam ediyor.");
                    break;
                case MyStaticVariables.Sonuclandi:
                    Console.WriteLine("Başvuru sonuçlandı.");
                    break;
                default:
                    Console.WriteLine("Geçersiz başvuru durumu.");
                    break;
            }
        }
    }
}