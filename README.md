# 💰 CurrencyTracker

**CurrencyTracker**, Frankfurter API üzerinden gerçek zamanlı döviz kurlarını çeken, verileri hafızada saklayan ve LINQ kullanarak kolayca analiz etmenizi sağlayan, C# ile geliştirilmiş profesyonel bir konsol uygulamasıdır.

---

## 🚀 Proje Hakkında
Bu proje, finans firmalarının Türk Lirası (TRY) bazlı döviz kurlarını anlık olarak takip etmesini sağlamak amacıyla geliştirilmiştir.
Kullanıcılar, konsol üzerinden dövizleri görüntüleyebilir, arama ve filtreleme yapabilir, kurları sıralayabilir ve istatistiksel özetler alabilir.

---

## 🛠 Kullanılan Teknolojiler ve Yöntemler
Bu proje, modern C# / .NET teknolojileri kullanılarak geliştirilmiştir. Harici veri kaynaklarıyla etkileşim için HttpClient ve System.Text.Json kütüphanesi ile API entegrasyonu sağlanmıştır. Verilerin uygulama akışını engellemeden çekilebilmesi için asenkron programlama (async / await) kullanılmıştır.

Veri analizi ve filtreleme işlemleri için LINQ yoğun olarak kullanılmıştır. Uygulamada Select, Where, OrderBy, OrderByDescending, Count, Max, Min ve Average gibi LINQ operatörleri uygulanarak döviz verileri üzerinde hızlı ve esnek sorgulamalar yapılabilmektedir. Bu sayede kullanıcı, dövizleri listeleyebilir, filtreleyebilir, sıralayabilir ve istatistiksel özetler elde edebilir.

---

## ⚙️ Özellikler
Uygulama konsol arayüzü üzerinden interaktif bir şekilde şu işlemleri gerçekleştirir:

1.  **📑 Tüm Dövizleri Listele:** Güncel kurları (1 TRY karşılığı) detaylıca listeler.
2.  **🔍 Döviz Ara:** Belirli bir kod (örn: USD, EUR) girerek spesifik kur bilgisine ulaşmanızı sağlar.
3.  **🧪 Filtreleme:** Belirli bir değer eşiğinin üzerindeki kurları ayıklar.
4.  **📊 Sıralama:** Kurları fiyata göre küçükten büyüğe veya büyükten küçüğe organize eder.
5.  **📈 İstatistiksel Rapor:**
    * Toplam döviz sayısı
    * Piyasadaki en yüksek kur
    * Piyasadaki en düşük kur
    * Genel ortalama kur değeri

---

## 🔌 API Kaynağı
Proje, finansal verilerini güvenilir **Frankfurter API** üzerinden almaktadır.

* **ApiLink:** `https://api.frankfurter.app/latest?from=TRY`

---


<p align="center">
  <i>Bu proje bir eğitim final ödevi kapsamında geliştirilmiştir. © 2026</i>
</p>
