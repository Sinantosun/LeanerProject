Herkese Merhaba

Learner Project eğitim platformu gibi düşünebiliceğimiz bir uygulamadır. admin öğrenci ve öğretmen panelleri olmak üzere 3 panelden oluşmaktadır.

Projede MVC 5 yaklaşımı kullanıldı ve proje code first ile geliştirildi.


Projeye ait görseller

<h1>Admin Tarafının Dashborad alanı</h1>

![Image05](https://github.com/Sinantosun/LeanerProject/assets/145317724/13751ca3-08a9-4c9a-8af5-68d24ae6722b)

Bu alanda, en pahalı kursdan en ucuz kursa en popüler kursdan kursların genel ortalama fiyatlarını içeren ayrıca site içinde diğer verilerin istatistikleri de listeleniyor.
Ayrica bütün istatistikler dinamik olarak kategoriye göre çekiliyor yeni bir kategori eklendiğinde otomatik olarak hesaplanıyor.

<h1>Kurs Listesi</h1>

![Image06](https://github.com/Sinantosun/LeanerProject/assets/145317724/26068d9e-7ed8-443f-8028-7e4eb1e62b82)


Burada kurs adları, eğitmen adı kursa yapılan yapılan değerlendirmelerin 5 üzerinde ortalaması kursun video sayısı gibi bir çok özellik bulunuyor. Bu veriler ilişkili tablolar aracılığı ile taşınıyor.
Burada pagedList ile sayfalama kullanılmıştır. 

<h1>PagedList Nedir ?</h1>
<ul>
  <li>Web projelerinde, veritabanında bulunan binlerce satırlık verilerle hizmet vermemiz gereken noktalarda sayfalamayı tercih ederiz.</li>
  <li>Verileri listelediğiniz bir sayfada tüm verileri göstermek yerine belirli sayıda verileri gösterip, 1-2-3-4 şeklinde sayfa numarası atarak gösterme işlemidir.</li>
  
</ul>

Örneğin 150 adet kayıt var elinizde, listelediğiniz sayfada 150’sini birden değilde 20’şer 20’şer göstermek istiyorsanız paging mantığı burada devreye giriyor.
Yapılan projede her 6 kayıtta bir yeni bir sayfa oluşturuluyor.


<h1>Öğretmenlerin listesi</h1>

![Image02](https://github.com/Sinantosun/LeanerProject/assets/145317724/ff69eb61-0197-4d91-8684-50872e47cf49)

Bu alan sitenin Öğretmenlermiz sekmesi altında bulunuyor.
burada öğretmen adı ve öğretmenin yayınladığı kurs sayıları görünüyor ayrıca buton yardımıyla seçilen öğretmene ait kursların listesi de ayrı bir sayfada görüntülenebiliyor.


<h1>Öğrencilerin Panelinde kendi kurslarını görüntüledikleri alan</h1>
![Image03](https://github.com/Sinantosun/LeanerProject/assets/145317724/b8f59bb6-8240-4db7-adae-16521e80f3c5)

Bu alanda, giriş yapan öğrenciye ait kayıt olduğu kurslar listeleniyor. 
Öğrenciler, kayıt oldukları kurslara yaptığı yorumları silip düzenleyebilir.
Eğitime başla butonu ile kayıt oldukları kursaların videolarını izleyebilirler.


<h1>Eğitmenlerin Panelinde kendi yayınladıkları kurslarını görüntüledikleri alan</h1>

![Image04](https://github.com/Sinantosun/LeanerProject/assets/145317724/33ddf936-adc3-4e84-b3b2-64a24824bc03)

Bu alanda, eğitmenler yeni kurs yayınlayabilir, yayınladıkları kursaları kaldırabilir veya güncelleyebilir.
ayrıca kurslarına yapılan yorumları da görüntülüyebilir.


Eğtimen ve öğrenci panellerinde her iki panelde de profil ayarları mevcut, şifre adsoyad ve kullanıcı adı gibi verilerin güncellenmesi burada gerçekleştiriliyor.







