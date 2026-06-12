# 🛒 E-Ticaret Yazılım Test ve Kalite Analiz Projesi (Final)

## 👤 Öğrenci Bilgileri
* **Ad Soyad:** Berker Konuk
* **Öğrenci No:** 20230108038
* **Bölüm:** Bilgisayar Programcılığı
* **Üniversite:** Piri Reis Üniversitesi
* **Ders:** MTH2005 Yazılım Test ve Kalitesi
* **Öğretim Görevlisi** Emrah SARIÇİÇEK
* **Teslim Tarihi:** 12/06/2026

---

## 📝 Proje Özeti
Bu proje, "Yazılım Test ve Kalitesi" dersi final projesi kapsamında geliştirilmiştir. STLC (Software Testing Life Cycle) süreçlerine sadık kalınarak, uçtan uca bir e-ticaret akışı üzerinde **Equivalence Partitioning (EP)** ve **Boundary Value Analysis (BVA)** teknikleri uygulanmıştır.

İçerisinde proje isterlerine uygun olarak bilinçli şekilde bırakılmış **mantıksal hatalar (bug)** barındıran bir .NET 9 uygulamasıdır. Projenin temel amacı; Unit, Integration, White-Box, Black-Box ve Gray-Box test tekniklerini kullanarak sistemdeki açıkları **NUnit** framework'ü ile tespit etmektir.

---

## 🏗️ Proje Mimarisi

Sistem, bir e-ticaret akışını (Ürün -> Sepet -> Sipariş -> Ödeme) simüle eden modüllerden oluşur:

* **Core/**: İş mantığının (Business Logic) bulunduğu sınıflardır (`Product.cs`, `Cart.cs`, `OrderService.cs`).
* **Tests/**: NUnit test senaryolarının bulunduğu klasördür.
* **Program.cs**: Uygulama derlendiğinde (F5), tüm test senaryolarının özet sonuçlarını görsel bir konsol raporu halinde sunan giriş noktasıdır.

---

## 🐛 Enjekte Edilen Bilinçli Hatalar (Defect / Bug List)

Final analizi kapsamında tespit edilmesi için sisteme aşağıdaki 5 kritik hata eklenmiştir:

1. **İndirim Oranı Hatası (Cart.cs - Critical):** 100 TL üzeri sepetlere uygulanması gereken %10 indirim (`total * 0.9m`) yerine kodda yanlışlıkla %50 indirim (`total * 0.5m`) uygulanmaktadır.
2. **Kargo Maliyet Hatası (Cart.cs - High):** Sepet toplamına eklenmesi gereken sabit kargo ücreti (25.0m), operatör hatası nedeniyle toplam tutardan **çıkarılmaktadır (-)**.
3. **Stok Sınır Değer Zafiyeti (OrderService.cs - High):** Sipariş onayı sırasında stok sıfır (0) olduğunda satışın engellenmesi gerekirken, sistem sadece negatif (<0) stokları kontrol ettiği için sıfır stoğu kabul edip ürün adedini -1'e düşürmektedir.
4. **Minimum Sipariş Limiti Hatası (OrderService.cs - Medium):** Gereksinimlerde minimum sipariş tutarı 100 TL olarak belirlenmiş olmasına rağmen, kod içerisinde limit `total < 10` olarak kontrol edilmektedir.
5. **Ödeme Doğrulama Hatası (OrderService.cs - High):** Müşterinin eksik ödeme yapması durumunda hata fırlatması gereken sistem, hatalı operatör kullanımı (`paymentAmount > total`) nedeniyle sadece fazla ödemelerde hata vermektedir.

---

## 🧪 Uygulanan Test Senaryoları ve Sonuçları

NUnit kullanılarak EP ve BVA teknikleriyle hazırlanan toplam **20 farklı senaryo** sonucunda sistemin kararlılığı ölçülmüştür. Mantık hatalarına çarpan 9 senaryo kırmızı (FAIL) olarak raporlanmıştır.

**Test Özeti:**
* Toplam Senaryo: 20
* Başarılı (PASS): 11
* Başarısız (FAIL): 9

### 🔴 BAŞARISIZ (FAIL) OLAN TESTLERİN ANALİZİ (9 Test)

* **[White Box] İndirim ve Kargo Hesaplama Senaryoları:** TC03, TC04, TC05 ve TC06 numaralı testler, sepet tutarından kargo ücretinin çıkarılması ve indirim miktarının yanlış hesaplanması nedeniyle FAIL vermiştir.
* **[Integration] Stok Kontrol (BVA) Senaryosu:** TC13 numaralı sınır değer testi, sepetinde tam 0 stoklu ürün olan müşterinin siparişinin onaylanması sebebiyle FAIL vermiştir.
* **[Integration] Minimum Sipariş (BVA) Senaryosu:** TC16 numaralı test, 99 TL'lik sepetin sistemden hata almadan geçmesi nedeniyle FAIL vermiştir.
* **[Integration] Ödeme Mantığı Senaryoları:** TC10 ve TC11 numaralı testler, eksik ve fazla ödeme durumlarındaki ters mantık hatası yüzünden FAIL vermiştir.
* **[Black Box] Çoklu Ürün Testi:** TC18 ve TC20 numaralı testler, kargo hatasının genel toplamı eksi değerlere düşürmesi sonucu patlamıştır.

---

### 🟢 BAŞARILI (PASS) OLAN TESTLER (11 Test)

Sistemin kararlı çalışan kısımları doğrulanmıştır. Öne çıkan başarılı senaryolar:
* `[Black Box] ` Sepete Ürün Ekleme ve Çıkarma doğruluk kontrolleri. (TC01, TC02)
* `[Gray Box]  ` Boş sepetle sipariş verilmesinin (Exception ile) engellenmesi. (TC07)
* `[Integration]` Geçerli stokla sorunsuz sipariş verme ve stok adetinin doğru düşümü. (TC08, TC09, TC12)
* `[Integration]` Tam 100 TL ve üzeri geçerli ödeme limiti kontrolleri. (TC15, TC19)
* `[Black Box] ` Negatif (-1) stokla siparişin doğru bir şekilde Exception fırlatması. (TC14)

---

## 🚀 Projeyi Çalıştırma

1. Projeyi GitHub üzerinden klonlayın.
2. `ECommerceApp.sln` dosyasını Visual Studio 2022 (veya güncel bir IDE) ile açın.
3. Testleri çalıştırmak için üst menüden **Test > Run All Tests** (veya Visual Studio Test Explorer) seçeneğini kullanın.
4. Sistemin görsel rapor özetini görmek için uygulamayı `F5` tuşu ile başlatın.
