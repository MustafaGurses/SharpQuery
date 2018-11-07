# SharpQuery
SharpQuery uzak MSSQL bağlantısı ve local MSSQL Server bağlantısını
yapmanızı sağlıyor.Aşağıda ki özellikleri local ve uzak mssql serverınız için gerçekleştire bilirsiniz.(Backup işlemi Uzak sunucu için test edilmedi.)
SharpQuery tüm windows versionları ve MSSQL versionlarında çalışabilmekte.
Peki özellikleri nelerdir?
Veritabanları için;

Her veritabanı için 1 den fazla SQL sorgusu yazabilme,.sql scripti çalıştırabilme,
Veritabanı oluşturma,
Veritabanı için tablo oluşturma(identity ayarı,allow nulls ayarı,primary key ayarı),
Veritabanı yedeği alabilme(Manuel),
Veritabanı geri yükleme(Manuel Restore DataBase),
Veritabanı silme.

Tablolar için;
SQL Management studio ile aynı şekilde Edit Top 200rows işlemi yapabilme,
Tabloda ki kolonları listeleyebilme(Örneğin:kullaniciAdi(varchar(50)),
Tablo için Truncate Table komutu uygulayabilme,
Tabloyu silebilme.

Sorgu Ekranı;
Sağ tık ile;
Otomatik SQL Sorguları yazabilme(Veri tipleri uyumlu),
Otomatik C# dili için method oluşturma(Tablonuzda ki kolonların veri tipine göre),

Auto Backup (Otomatik Yedekleme Sistemi);
Ayarladığınız dakika,saat,gün,ay,yıl için seçilen veritabanlarını zamanı geldiğinde yedekler.

Tam source indirmek için : https://goo.gl/FrHqE5
