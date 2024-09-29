![10](https://github.com/user-attachments/assets/d2d5d605-11ba-4988-9602-bdbd651e8965)
1- Kitap Yönetimi:

Kütüphane içindeki kitapların detaylı bir şekilde kaydedilmesi, listelenmesi, düzenlenmesi ve silinmesi işlevlerini içerir. Kullanıcılar, kitapların başlık, yazar, tür, yayın tarihi, ISBN numarası ve mevcut kopya sayısı gibi bilgilerini kaydedebilirler. Ayrıca, kitaplar arasında arama yapabilir ve istedikleri kitabın tüm detaylarına ulaşabilirler.

2- Kullanıcı Yönetimi:

Kullanıcı yönetimi modülü, üye kayıt ve giriş işlemlerini kapsar. Kullanıcılar, sisteme kaydolduktan sonra kütüphanedeki kitapları görüntüleyebilir ve sisteme yeni kitaplar ya da yazarlar ekleyebilirler. Kullanıcıların güvenliği için kayıt sırasında şifre doğrulaması yapılmakta, e-posta ve parola kombinasyonu ile sisteme giriş sağlanmaktadır. Hatalı giriş durumunda kullanıcıya geri bildirim verilir.

3- Nesne Yönelimli Programlama (OOP) Prensiplerine Dayalı Yapı:

Proje, Nesne Yönelimli Programlama (OOP) prensiplerine sıkı sıkıya bağlı kalarak yapılandırılmıştır. Bu yaklaşım, kodun modüler, genişletilebilir ve bakımı kolay bir hale getirilmesini sağlamaktadır. Her bir kitap, yazar ve kullanıcı ayrı birer model olarak tanımlanmış olup, ilişkiler (örneğin bir kitabın bir yazara ait olması) açık bir şekilde tanımlanmıştır. Bu sayede kod, gerçek dünyadaki kütüphane yapısını yansıtır.

4- MVC Mimarisi:

Proje, Model-View-Controller (MVC) mimarisi ile yapılandırılmıştır. Bu mimari, uygulamanın üç temel bileşene ayrılmasını sağlar:

Model (Veri Katmanı): Verilerin nasıl saklanacağı, ilişkilerinin nasıl tanımlanacağı ve iş kurallarının nasıl işleyeceği burada belirlenir. Kitap, yazar ve kullanıcılar için ayrı modeller oluşturulmuştur. View (Görünüm Katmanı): Kullanıcıya sunulan sayfalar bu katmanda oluşturulur. Kitap ve yazar listeleri, detay sayfaları, kullanıcı giriş ve kayıt ekranları gibi bileşenler burada tasarlanır. Controller (İşlem Katmanı): Kullanıcıdan gelen isteklerin nasıl işleneceği, hangi verilerin görünüme sunulacağı gibi işlemler bu katmanda gerçekleştirilir. Kitap, yazar ve kullanıcı işlemleri için ayrı controller'lar oluşturulmuştur.

5- Dinamik ve Etkileşimli Kullanıcı Arayüzü:

Kullanıcı arayüzü, son kullanıcıya sade ve işlevsel bir deneyim sunacak şekilde tasarlanmıştır. Kullanıcılar, kolayca kitap ekleyebilir, düzenleyebilir veya silebilir. Aynı şekilde yazarlar da yönetilebilir. Kullanıcı dostu formlar ve uyarı mesajları sayesinde hata yapma ihtimali minimize edilmiştir. Şifre doğrulama, eksik bilgi uyarıları ve hatalı girişlerde yönlendirme gibi özellikler de kullanıcı deneyimini geliştirir.

6- Veritabanı Entegrasyonu:

Projede kullanılan Entity Framework Core ile veritabanı işlemleri hızlı ve güvenli bir şekilde gerçekleştirilir. Veritabanında kitap, yazar ve kullanıcı bilgilerinin saklanması, güncellenmesi ve silinmesi işlemleri ORM (Object Relational Mapping) yaklaşımıyla yönetilir.

Kullanılan Teknolojiler: ASP.NET Core MVC, SQL Server, LINQ (Language Integrated Query)
