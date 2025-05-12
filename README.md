# Otel Yönetim Sistemi

Bu proje, ASP.NET Core teknolojisi kullanılarak geliştirilmiş kapsamlı bir otel yönetim sistemidir. API ve Web UI bileşenlerinden oluşan katmanlı mimarisi sayesinde, otel yöneticileri odaları, personeli, hizmetleri ve rezervasyonları kolayca yönetebilirken, misafirler giriş yapmadan otel bilgilerini inceleyebilir ve rezervasyon yapabilirler.

## Mimari Yapı

Proje, aşağıdaki bileşenlerden oluşan temiz bir mimari yaklaşımı takip etmektedir:

### API Katmanı (ApiConsume)
- **HotelProjectWebApiConsume**: Frontend'e veri sağlayan ana API projesi
- **HotelProject.EntityLayer**: Veri modellerini ve varlıkları içerir
- **HotelProject.DataAccessLayer**: Entity Framework Core ile veritabanı işlemlerini yönetir
- **HotelProject.BusinessLayer**: İş mantığını ve servis uygulamalarını içerir

### Frontend Katmanı
- **HotelProject.WebUI**: API'yi tüketen ve kullanıcı arayüzünü oluşturan ASP.NET Core MVC projesi

### Ek Servisler
- **RapidApi**: Gelişmiş işlevsellik için harici API entegrasyonları

## Özellikler

### Genel Kullanıcı Özellikleri (Giriş Gerektirmez)
- Otel odalarını ve hizmetlerini inceleme
- Personel bilgilerini görüntüleme
- Misafir yorumlarını okuma
- Oda rezervasyonu yapma
- Otelle iletişime geçme
- Bültenlere abone olma

### Yönetici Özellikleri (Kimlik Doğrulama Gerektirir)
- Oda yönetimi (ekleme, güncelleme, silme)
- Personel yönetimi
- Rezervasyon yönetimi
- Misafir yönetimi
- Hizmetler ve yorumlar için içerik yönetimi
- İstatistikler ve analizlerle donatılmış yönetim paneli

## Teknoloji Altyapısı

- **Backend**: ASP.NET Core 6.0
- **Frontend**: ASP.NET Core MVC, HTML, CSS, JavaScript
- **Veritabanı**: SQL Server Express
- **ORM**: Entity Framework Core
- **Kimlik Doğrulama**: ASP.NET Core Identity
- **API İletişimi**: HttpClient

## Kurulum Talimatları

### Gereksinimler
- .NET 6.0 SDK veya daha yenisi
- SQL Server Express
- Visual Studio 2022 (önerilen)

### Veritabanı Yapılandırması
Proje, aşağıdaki bağlantı dizesiyle SQL Server Express kullanmak üzere yapılandırılmıştır:
```
Data Source=.\SQLEXPRESS;Initial Catalog=ApiHotelDb;Integrated Security=True;TrustServerCertificate=True
```

Uygulama başlatıldığında veritabanı otomatik olarak oluşturulacaktır. Ayrıca migration işlemi yapmaya gerek yoktur.

### Projeyi Çalıştırma
1. Depoyu bilgisayarınıza klonlayın
2. Çözümü Visual Studio'da açın
3. Hem API (HotelProjectWebApiConsume) hem de WebUI projelerini başlangıç projeleri olarak ayarlayın
4. Uygulamayı çalıştırın

### API Uç Noktaları
API, `http://localhost:5150` adresinde çalışır ve şu uç noktaları içerir:
- `/api/Room` - Oda yönetimi
- `/api/Staff` - Personel yönetimi
- `/api/Service` - Hizmet yönetimi
- `/api/Booking` - Rezervasyon yönetimi
- `/api/Testimonial` - Misafir yorumları
- `/api/Contact` - İletişim mesajları
- Ve daha fazlası...

## Proje Yapısı

### Controller'lar
WebUI projesindeki controller'lar işlevlerine göre düzenlenmiştir ve şunları içerir:
- `HomeController` - Ana sayfa
- `ServiceController` - Otel hizmetleri
- `StaffController` - Personel bilgileri
- `BookingController` - Rezervasyon işlevselliği
- `ContactController` - İletişim bilgileri ve mesajlaşma
- `TestimonialController` - Misafir değerlendirmeleri ve yorumları
- `LoginController` - Kimlik doğrulama
- Arka uç yönetimi için çeşitli admin controller'ları

### Veritabanı Tabloları
Projedeki ana veritabanı tabloları:
- `Rooms` - Otel odaları bilgileri
- `Services` - Sunulan hizmetler
- `Staffs` - Personel kayıtları
- `Bookings` - Rezervasyon bilgileri
- `Testimonials` - Müşteri değerlendirmeleri
- `Contacts` - İletişim mesajları
- `Guests` - Misafir kayıtları
- `AspNetUsers` - Kullanıcı hesapları

### Kimlik Doğrulama
- Proje, kimlik doğrulama için ASP.NET Core Identity kullanır
- Yönetici alanları kimlik doğrulama gerektirir
- `[AllowAnonymous]` özniteliği sayesinde genel alanlar giriş yapmadan erişilebilir
- Giriş yolu `/Login/Index/` olarak yapılandırılmıştır

## Kullanım Kılavuzu

### Misafir Kullanıcılar İçin
1. Ana sayfada otel hakkında genel bilgilere erişebilirsiniz
2. "Odalar" sayfasından mevcut odaları inceleyebilirsiniz
3. "Hizmetler" sayfasından otelin sunduğu hizmetleri görebilirsiniz
4. "Rezervasyon" sayfasından konaklama için rezervasyon yapabilirsiniz
5. "İletişim" sayfasından otele mesaj gönderebilirsiniz

### Yöneticiler İçin
1. `/Login/Index` sayfasından admin hesabınızla giriş yapın
2. Yönetim panelinden tüm içeriği yönetebilirsiniz
3. Rezervasyonları onaylayabilir veya reddedebilirsiniz
4. Personel, oda ve hizmet bilgilerini güncelleyebilirsiniz
5. Müşteri yorumlarını ve mesajlarını yönetebilirsiniz

## Sorun Giderme

- **Veritabanı Bağlantı Hatası**: SQL Server Express'in yüklü ve çalışır durumda olduğundan emin olun
- **API Bağlantı Sorunu**: API projesinin çalıştığından ve doğru portta hizmet verdiğinden emin olun
- **Giriş Yapamama**: Veritabanının doğru şekilde oluşturulduğundan emin olun, gerekirse admin hesabını manuel olarak oluşturun

## Katkıda Bulunma
Projeyi geliştirmek için katkıda bulunmak isteyenler aşağıdaki adımları izleyebilir:
1. Depoyu fork edin
2. Yeni bir dal (branch) oluşturun
3. Değişikliklerinizi yapın
4. Pull request gönderin

## Lisans
Bu proje kişisel ve eğitim amaçlı kullanım için uygundur.
