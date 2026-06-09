using System;

namespace ECommerceApp;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Yazılım Test ve Kalite Analizi - Final Raporu";
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("==================================================");
        Console.WriteLine("   E-TİCARET TEST OTOMASYONU VE RAPOR ARAYÜZÜ     ");
        Console.WriteLine("==================================================\n");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Analiz Türü: Unit, Black Box, Gray Box, Integration");
        Console.WriteLine("Test Teknikleri: Equivalence Partitioning (EP), Boundary Value Analysis (BVA)");
        Console.WriteLine("Toplam Senaryo: 20\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--- \u2714 BAŞARILI (PASS) OLAN TESTLER (11 Test) ---");
        Console.WriteLine(" -> Sepete Ürün Ekleme ve Çıkarma İşlemleri (Black Box)");
        Console.WriteLine(" -> Boş Sepetle Sipariş Engelleme (Gray Box)");
        Console.WriteLine(" -> Geçerli Stokla Sipariş Verme ve Stok Düşümü (Integration)");
        Console.WriteLine(" -> Negatif (-1) Stokla Sipariş Engeli (Integration - BVA)");
        Console.WriteLine(" -> Tam 100 TL ve Üzeri Geçerli Limit Kontrolleri (Integration)\n");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("--- \u274c TESPİT EDİLEN HATALAR / BUGLAR (9 Test Failed) ---");
        
        Console.WriteLine(" 1. [White Box] İndirim Hesaplama Hatası");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("    - Neden: %10 yapılması gereken indirimin kodda yanlışlıkla %50 uygulanması.\n");
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(" 2. [White Box] Kargo Ücreti Mantık Hatası");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("    - Neden: 25 TL kargo ücretinin toplama (+) yerine çıkarma (-) ile hesaplanması.\n");
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(" 3. [Integration] Stok Kontrol Zafiyeti (Boundary Value)");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("    - Neden: Stok tam 0 olduğunda sistemin siparişi onaylayıp stoğu -1'e düşürmesi.\n");
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(" 4. [Integration] Minimum Sipariş Limiti Hatası");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("    - Neden: 100 TL olması gereken minimum limitin, kodda 10 TL olarak unutulması.\n");
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(" 5. [Integration] Ödeme Doğrulama Hatası");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("    - Neden: Eksik ödemede işlem geçip, fazla ödemede ArgumentException fırlatması.\n");

        Console.ResetColor();
        Console.WriteLine("==================================================");
        Console.WriteLine("\nÇıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
