# RentaCarProject
Kodlama.io kamp gelisim projesidir. Gelistiren Rahim Cubuk.

Uygulama gelistirme surecinde back-end tarafında cok katmanli mimari kullanılmıştır. Uygulama AOP, FluentValidatın, Autofac, WebAPI ile güclendirilmiş ve SOLID kurallarına bağlı kalınmıştır.

### Geliştirme Ortam Bilgileri
* Geliştirme aşamasında "Microsoft Blend for Visual Studio Community 2019 Version 16.8.5" kullanılmıştır.
* Veritabanı olarak MsSQL kullanılmış ve veritabanı ile iletişim "Microsoft.EntityFrameworkCore.SqlServer v3.1.11" ile sağlanmıştır.
* Veritabanı "Microsoft SQL Server Management Studio 11.0.3000.0" ile tasarlanıştır.
* [Frontend](https://github.com/rahimcubuk/RentaCarUI) gelistirme asamasinda "Visual Studio Code 1.54.1" kullanilmistir.
NOT: Verıtabanı dosyaları "Entities/Database" klasörü içerisindedir. Uygun bir programda(min SQL server 12) script.sql dosyasını çalıştırırsanız veritabanı bilgisayarınıza yüklenmiş olacaktır. Sonrasında uygulamayı kullanmaya başlayabilirsiniz.

### Kodlama.io 15. gun odev gereksinimleri
* Cache, Transaction ve Performance aspectlerini ekleyiniz.

### Kodlama.io 14. gun odev gereksinimleri
* RentACar projenize JWT entegrasyonu yapınız.

### Kodlama.io 13. gun odev gereksinimleri
* CarImages (Araba Resimleri) tablosu oluşturunuz. (Id,CarId,ImagePath,Date) Bir arabanın birden fazla resmi olabilir.
* Api üzerinden arabaya resim ekleyecek sistemi yazınız.
* Resimler projeniz içerisinde bir klasörde tutulacaktır. Resimler yüklendiği isimle değil, kendi vereceğiniz GUID ile dosyalanacaktır.
* Resim silme, güncelleme yetenekleri ekleyiniz.
* Bir arabanın en fazla 5 resmi olabilir.
* Resmin eklendiği tarih sistem tarafından atanacaktır.
* Bir arabaya ait resimleri listeleme imkanı oluşturunuz. (Liste)
* Eğer bir arabaya ait resim yoksa, default bir resim gösteriniz. Bu resim şirket logonuz olabilir. (Tek elemanlı liste)

### Kodlama.io 12. gun odev gereksinimleri
* Car Rental Projenize Autofac desteği ekleyiniz.
* Car Rental Projenize FluentValidation desteği ekleyiniz.
* Car Rental Projenize AOP desteği ekleyiniz.
* ValidationAspect ekleyiniz.

### Kodlama.io 11. gun odev gereksinimleri
* WebAPI katmanını kurunuz.
* Business katmanındaki tüm servislerin Api karşılığını yazınız.

### Kodlama.io 10. gun odev gereksinimleri
* Core katmanında Results yapılandırması yapınız.
* Kullanıcılar tablosu oluşturunuz. Users-->Id,FirstName,LastName,Email,Password
* Müşteriler tablosu oluşturunuz. Customers-->UserId,CompanyName
* Kullanıcılar ve müşteriler ilişkilidir.
* Arabanın kiralanma bilgisini tutan tablo oluşturunuz. Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi), ReturnDate(Teslim Tarihi). Araba teslim edilmemişse ReturnDate null'dır.
* Projenizde bu entity'leri oluşturunuz.
* CRUD operasyonlarını yazınız.
* Yeni müşteriler ekleyiniz.
* Arabayı kiralama imkanını kodlayınız. Rental-->Add
* Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.

### Kodlama.io 9. gun 1. odev gereksinimleri
CarRental Projenizde Core katmanı oluşturunuz.
* IEntity, IDto, IEntityRepository, EfEntityRepositoryBase dosyalarınızı 9. gün dersindeki gibi oluşturup ekleyiniz.
* Car, Brand, Color sınıflarınız için tüm CRUD operasyonlarını hazır hale getiriniz.
* Console'da Tüm CRUD operasyonlarınızı Car, Brand, Model nesneleriniz için test ediniz. GetAll, GetById, Insert, Update, Delete.
* Arabaları şu bilgiler olacak şekilde listeleyiniz. CarName, BrandName, ColorName, DailyPrice. (İpucu : IDto oluşturup 3 tabloya join yazınız)

### Kodlama.io 8. gun 1. odev gereksinimleri
Car nesnesine ek olarak;
* Brand ve Color nesneleri ekleyiniz(Entity)
* * Brand-->Id,Name
* * Color-->Id,Name
* Sql Server tarafında yeni bir veritabanı kurunuz. Cars,Brands,Colors tablolarını oluşturunuz. (Araştırma)
* Sisteme Generic IEntityRepository altyapısı yazınız.
* Car, Brand ve Color nesneleri için Entity Framework altyapısını yazınız.
* GetCarsByBrandId , GetCarsByColorId servislerini yazınız.
* Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.
* * Araba ismi minimum 2 karakter olmalıdır
* * Araba günlük fiyatı 0'dan büyük olmalıdır.

### Kodlama.io 7. gun 2. odev gereksinimleri
* Entities, DataAccess, Business ve Console katmanlarını oluşturunuz.
* Bir araba nesnesi oluşturunuz. "Car"
* Özellik olarak : Id, BrandId, ColorId, ModelYear, DailyPrice, Description alanlarını ekleyiniz. (Brand = Marka)
* InMemory formatta GetById, GetAll, Add, Update, Delete oprasyonlarını yazınız.
* Consolda test ediniz.


Yardım, destek, öneri için rahimcubuk@gmail.com adresine mail atabilirsiniz.
