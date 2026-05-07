<div align="center">

# 🌍 Travix

### ASP.NET Core ile geliştirilmiş modern otel keşif ve seyahat platformu

Gerçek zamanlı otel listeleme, gelişmiş filtreleme, yapay zeka destekli iletişim sistemi ve canlı veri entegrasyonları.

<br>

<img src="https://img.shields.io/badge/.NET-8-blueviolet?style=for-the-badge" />
<img src="https://img.shields.io/badge/ASP.NET-Core-darkblue?style=for-the-badge" />
<img src="https://img.shields.io/badge/EntityFramework-Core-green?style=for-the-badge" />
<img src="https://img.shields.io/badge/SQL-Server-red?style=for-the-badge" />
<img src="https://img.shields.io/badge/OpenAI-AI-black?style=for-the-badge" />
<img src="https://img.shields.io/badge/TailwindCSS-UI-38BDF8?style=for-the-badge" />

</div>

---

# 🚀 Proje Hakkında

Travix, kullanıcıların farklı şehirlerdeki otelleri gerçek zamanlı API verileri ile keşfedebildiği modern bir seyahat platformudur.

Kullanıcılar Travix üzerinden:

🔹 Şehir bazlı otel arayabilir  
🔹 Dinamik filtreleme yapabilir  
🔹 Otel detaylarını inceleyebilir  
🔹 Canlı hava durumu verilerini görüntüleyebilir  
🔹 Güncel döviz kurlarını takip edebilir  
🔹 Yapay zeka destekli destek sistemi ile iletişim kurabilir  

---

# ✨ Özellikler

## 👤 Kullanıcı Tarafı

- Gerçek zamanlı otel listeleme
- Gelişmiş filtreleme sistemi
- Otel detay sayfası
- Blog sistemi
- İletişim sistemi
- Yapay zeka destekli mesaj sistemi
- Canlı hava durumu kartları
- Canlı döviz kartları
- Responsive premium UI
- Stich AI ile oluşturulan modern arayüz tasarımı

## ⚙️ Admin Panel

- Hero yönetimi
- Blog yönetimi
- Yorum yönetimi
- Mesaj yönetimi
- AI cevap görüntüleme
- İçerik yönetimi
- Stich AI ile oluşturulan modern dashboard tasarımı

# 🏗 Mimari Yapı

Travix, frontend ve backend sorumluluklarını birbirinden ayıran **2 projeli katmanlı mimari** ile geliştirilmiştir.

```text
                 Travix (MVC UI)
                        ↓
                  Consume API
                        ↓
                 WebAPI Project
                 ↙            ↘
          SQL Server       RapidAPI
```

### Katmanların görevleri:

#### 🔹 Travix (UI Katmanı)

- Razor View render işlemleri
- Kullanıcı etkileşimleri
- Form işlemleri
- API’den gelen verileri consume etme
- Doğrudan veritabanı veya dış API erişimi yoktur

#### 🔹 WebAPI (Backend Katmanı)

- Entity Framework işlemleri
- CRUD operasyonları
- SQL Server veri yönetimi
- RapidAPI entegrasyonu
- JSON response üretimi

#### 🔹 SQL Server

- Blog verileri
- Hero içerikleri
- Kullanıcı mesajları
- AI cevapları
- Yönetim paneli verileri

#### 🔹 RapidAPI

- Destination arama
- Otel listeleme
- Otel detay verileri
- Gerçek zamanlı dış servis verileri

---

# ⚡ API Çalışma Mantığı

Travix, otel verilerini getirmek için **RapidAPI üzerinden ardışık iki HTTP isteği** kullanır.

```text
Şehir Bilgisi → Destination ID → Otel Listeleme
```

İlk istekte kullanıcının girdiği şehir bilgisi gönderilir ve ilgili **Destination ID** alınır.

İkinci istekte elde edilen **Destination ID**, tarih, kişi sayısı, oda sayısı, para birimi, dil ve fiyat filtreleri ile birlikte gönderilir ve gerçek zamanlı otel verileri kullanıcıya listelenir.

---

# 🛠 Kullanılan Teknolojiler

- ASP.NET Core 8
- ASP.NET Core MVC
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Razor View Engine
- TailwindCSS
- JavaScript
- HTML5
- CSS3
- RapidAPI
- OpenAI API

---

# 🤖 Yapay Zeka Entegrasyonu

Travix içerisinde OpenAI entegrasyonu bulunmaktadır.

Kullanıcı iletişim formunu doldurduğunda:

🔹 Mesaj analiz edilir  
🔹 Profesyonel cevap oluşturulur  
🔹 Veritabanına kaydedilir  
🔹 Admin panel üzerinden görüntülenebilir  

Bu yapı müşteri destek sürecini otomatik hale getirir.

---

# 📸 Ekran Görüntüleri

# 🏠 Anasayfa

![anasayfa1](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/a1.png?raw=true)

![anasayfa2](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/a2.png?raw=true)

![anasayfa3](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/a3.png?raw=true)

![anasayfa4](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/a4.png?raw=true)

![anasayfa5](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/a5.png?raw=true)

![anasayfa6](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/a6.png?raw=true)

![anasayfa7](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/a7.png?raw=true)

![anasayfa8](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/a8.png?raw=true)

---

# 🏨 Otel Listeleme

![otel-listesi](https://github.com/user-attachments/assets/bf03e94e-451c-434f-a22d-c77ec6fff876)

---

# 🏨 Otel Detay

![otel-detay](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/d5.png?raw=true)

---

# 📰 Blog Sayfası

![blog](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/blog_index.png?raw=true)

---

# 📩 İletişim Sayfası

![contact](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/contact_index.png?raw=true)

---

# ⚙️ Admin Panel

## Otel Ayarları

![otel-ayar](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/otelayar.png?raw=true)

## Mesaj Yönetimi

![mesajlar](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/mesajlar.png?raw=true)

![mesaj-detay](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/mesajdetay.png?raw=true)

## Hero Yönetimi

![hero-list](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/herolist.png?raw=true)

![hero-create](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/herocreate.png?raw=true)

## Blog Yönetimi

![blog-list](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/bloglist.png?raw=true)

![blog-create](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/blogcreate.png?raw=true)

## Yorum Yönetimi

![yorum-list](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/yorumlist.png?raw=true)

![yorum-create](https://github.com/furkanturkerr/Travix/blob/main/Travix.WebUI/wwwroot/%C4%B0magesProject/yorumcreaate.png?raw=true)

---
