# Hafta 02 İnceleme Notları

**Proje:** CodeLens AI – AI Destekli Kod İnceleme Asistanı  
**İncelenen Doküman:** YK – Tasarım Dokümanı.pdf  
## 1. İncelemenin Amacı

Bu incelemenin amacı, CodeLens AI projesinin tasarım dokümanını değerlendirmek ve sistem mimarisini, bileşenlerini, veri yapısını, kullanıcı arayüzünü, güvenlik ve performans kararlarını anlamaktır.

## 2. İncelenen Konular

- Sistem genel bakışı ve ana bileşenler incelendi.
- Katmanlı (Layered/Clean Architecture) mimari yaklaşımı değerlendirildi.
- İstemci, sunucu ve veritabanı teknolojileri belirlendi.
- Kod inceleme sürecinin adımları incelendi.
- Yapay zekâ istem tasarımı ve API uç noktaları değerlendirildi.
- Veritabanı yapısı ve veri yönetimi incelendi.
- Kullanıcı arayüzü ve gezinme akışı değerlendirildi.
- Güvenlik ve performans tasarım kararları incelendi.
- Gereksinim ve tasarım bileşenleri arasındaki izlenebilirlik bölümü kontrol edildi.

## 3. İnceleme Sonuçları

Tasarım dokümanında sistemin istemci-sunucu mimarisiyle geliştirilmesi planlanmıştır. Sunucu tarafında ASP.NET Core Web API ve C#, istemci tarafında HTML5, CSS3, JavaScript, Bootstrap 5 ve Monaco Editor kullanılmaktadır.

Veri yönetimi için Entity Framework Core ve SQLite tercih edilmiştir. Mimari katmanlar arasındaki bağımlılıkların düzenli tutulması ve dış yapay zekâ servisinin bir arayüz arkasında soyutlanması planlanmıştır.

Kod inceleme süreci; kodun gönderilmesi, girdinin doğrulanması, yapay zekâ servisine iletilmesi, yanıtın kontrol edilmesi ve sonuçların veritabanına kaydedilmesi adımlarından oluşmaktadır.

Güvenlik, performans, veri yönetimi ve kullanıcı arayüzü konularında tasarım kararlarına yer verilmiştir.

## 4. Değerlendirme

Tasarım dokümanı, gereksinim dokümanında tanımlanan sistem işlevlerinin teknik olarak nasıl gerçekleştirileceğini açıklamaktadır. Mimari yapı, temel bileşenler ve inceleme akışı anlaşılır şekilde tanımlanmıştır.

Uygulama geliştirme aşamasında dokümanda belirtilen tasarım kararlarının gerçekleştirilmesi ve gereksinimlerle uyumunun test edilmesi gerekmektedir.

## 5. Sonuç

Yazılım tasarım dokümanı incelenmiş, sistemin mimari yaklaşımı, temel bileşenleri, veri tasarımı, kullanıcı arayüzü ve güvenlik kararları değerlendirilmiştir. Doküman, geliştirme aşamasında başvurulacak temel teknik kaynak olarak kullanılacaktır.