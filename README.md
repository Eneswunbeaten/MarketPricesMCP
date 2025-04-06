# Market Price Comparison Server (MCP)

<div align="center" id="top">

[![EN](https://img.shields.io/badge/Language-English-blue.svg)](#english)
[![TR](https://img.shields.io/badge/Dil-Türkçe-red.svg)](#turkish)

</div>

---

<a id="english"></a>

<div align="right">
<a href="#turkish">Türkçe</a>
</div>

## 📊 Market Price Comparison Server

A .NET-based Model Context Protocol (MCP) server application that compares grocery product prices across different markets in Turkey in real-time.

### Features

- Real-time price tracking for grocery products in Turkish markets
- Most affordable price identification with multi-market comparison
- Integration with MCP-compatible clients (like Claude and Cursor)

### Technology Stack

- .NET 8.0 Framework
- ModelContextProtocol package for data context management

### Installation

```bash
git clone https://github.com/Eneswunbeaten/MarketPricesMCP.git
cd MarketPricesMCP
dotnet restore
dotnet build
```

### Usage

This is an MCP server, not a traditional API. To use it, you need to integrate it with MCP-compatible client applications (like Claude or Cursor).

#### Integration with Claude

Add the following configuration to your `claude_desktop_config.json`:

```json
{
    "mcpServers": {
        "MarketPrices": {
            "command": "dotnet",
            "args": [
                "run",
                "--project",
                "PATH_TO_YOUR_PROJECT/MarketPricesMCP/MarketPricesMCP/MarketPricesMCP.csproj",
                "--no-build"
            ]
        }
    }
}
```

Replace `PATH_TO_YOUR_PROJECT` with the actual path to your project directory.

For example: `C://Users/username/Downloads`

#### Integration with Cursor

Cursor also supports MCP as a client. Follow these steps to integrate:

1. Open Cursor AI IDE
2. Go to **Settings** → **Features** → **MCP**
3. Click on **Add New MCP Server**
4. Fill in the configuration:
   - **Name**: `MarketPrices` (or any name you prefer)
   - **Type**: `command` (for local process)
   - **Command**: Add the following command:
   
   ```
   dotnet run --project "PATH_TO_YOUR_PROJECT/MarketPricesMCP/MarketPricesMCP/MarketPricesMCP.csproj" --no-build
   ```

   Replace `PATH_TO_YOUR_PROJECT` with your actual project path
5. Click **Add** to save
6. Verify that the server indicator in Cursor turns green (indicating successful connection)

**Troubleshooting Cursor Integration:**
- If you encounter a "no tools found" error, make sure you have Node.js installed (includes npm)
- Verify the MCP server is running correctly
- Check that the path to your project file is correct

#### For Other MCP-Compatible Systems

Configure the system to point to the MCP server's executable or project file according to the system's requirements.

**How to use:**
- Enter only the product name in Turkish (e.g., "salatalık", "domates", "süt")
- The tool will search across major Turkish grocery markets to find the best price
- Results include price comparison across multiple stores

### MCP Protocol Details

The Market Prices MCP server provides the following context types:

- `Title` - Information about a specific product
- `Brand` - Brand information
- `Price` - Product Price Amount
- `Market` - Name from Product's market

### Screenshots

<img src="https://github.com/user-attachments/assets/3f446a9e-a56c-4243-853d-936fc569471f" width="300" alt="Visual Studio Code Copilot Implementation">
<p><em>Working principle in Visual Studio Code Copilot</em></p>

<img src="https://github.com/user-attachments/assets/33d1298c-dddb-4106-9283-8d8ca9b5fb0d" width="300" alt="Visual Studio Code Copilot Output">
<p><em>Output in Visual Studio Code Copilot</em></p>

<div align="right">
<a href="#top">⬆️ Back to top</a>
</div>

---

<a id="turkish"></a>

<div align="right">
<a href="#english">English</a>
</div>

## 📊 Market Fiyat Karşılaştırma Sunucusu

Model Context Protocol (MCP) kullanılarak .NET ile geliştirilmiş, Türkiye'deki farklı marketlerdeki ürün fiyatlarını gerçek zamanlı olarak karşılaştıran bir sunucu uygulaması.

### Özellikler

- Türk marketlerindeki market ürünleri için gerçek zamanlı fiyat takibi
- En uygun fiyat tespiti ile çoklu market karşılaştırması
- MCP uyumlu istemcilerle (Claude ve Cursor gibi) entegrasyon

### Teknoloji Yığını

- .NET 8.0 Framework
- Veri context yönetimi için ModelContextProtocol paketi

### Kurulum

```bash
git clone https://github.com/Eneswunbeaten/MarketPricesMCP.git
cd MarketPricesMCP
dotnet restore
dotnet build
```

### Kullanım

Bu bir MCP sunucusudur, geleneksel bir API değildir. Kullanmak için MCP uyumlu istemci uygulamalarla (Claude veya Cursor gibi) entegre etmeniz gerekmektedir.

#### Claude ile Entegrasyon

`claude_desktop_config.json` dosyanıza aşağıdaki yapılandırmayı ekleyin:

```json
{
    "mcpServers": {
        "MarketPrices": {
            "command": "dotnet",
            "args": [
                "run",
                "--project",
                "PROJE_YOLUNUZ/MarketPricesMCP/MarketPricesMCP/MarketPricesMCP.csproj",
                "--no-build"
            ]
        }
    }
}
```

`PROJE_YOLUNUZ` kısmını kendi proje dizininizin gerçek yolu ile değiştirin.

Örneğin: `C://Users/kullaniciadi/Downloads`

#### Cursor ile Entegrasyon

Cursor da MCP protokolünü desteklemektedir. Entegrasyon için şu adımları izleyin:

1. Cursor AI IDE'yi açın
2. **Ayarlar** → **Özellikler** → **MCP** yolunu izleyin
3. **Yeni MCP Sunucusu Ekle** düğmesine tıklayın
4. Yapılandırmayı doldurun:
   - **İsim**: `MarketPrices` (veya istediğiniz bir isim)
   - **Tür**: `command` (yerel işlem için)
   - **Komut**: Aşağıdaki komutu ekleyin:
   
   ```
   dotnet run --project "PROJE_YOLUNUZ/MarketPricesMCP/MarketPricesMCP/MarketPricesMCP.csproj" --no-build
   ```

   `PROJE_YOLUNUZ` kısmını gerçek proje yolunuzla değiştirin
5. Kaydetmek için **Ekle**'ye tıklayın
6. Cursor'daki sunucu göstergesinin yeşil olduğunu doğrulayın (başarılı bağlantı anlamına gelir)

**Cursor Entegrasyonu Sorun Giderme:**
- "araç bulunamadı" hatası alırsanız, .Net'in kurulu olduğundan emin olun.
- MCP sunucusunun doğru çalıştığını kontrol edin
- Proje dosya yolunun doğru olduğundan emin olun

#### Diğer MCP Uyumlu Sistemler İçin

Sistemi, MCP sunucusunun yürütülebilir dosyasına veya proje dosyasına işaret edecek şekilde sistemin gereksinimlerine göre yapılandırın.

**Nasıl kullanılır:**
- Sadece Türkçe olarak ürün adını girin (örn. "salatalık", "domates", "süt")
- Araç, en iyi fiyatı bulmak için büyük Türk marketlerini tarayacaktır
- Sonuçlar, birden fazla mağaza arasında fiyat karşılaştırması içerir

### MCP Protokol Detayları

Market Fiyatları MCP sunucusu aşağıdaki bağlam türlerini sağlar:

- `Title` - Belirli bir ürün hakkında bilgi
- `Brand` - Marka bilgisi
- `Price` - Ürün fiyat tutarı
- `Market` - Ürünün market adı

### Ekran Görüntüleri

<img src="https://github.com/user-attachments/assets/3f446a9e-a56c-4243-853d-936fc569471f" width="300" alt="Visual Studio Code Copilot Üzerindeki Çalışma prensibi">
<p><em>Visual Studio Code Copilot Üzerindeki Çalışma prensibi</em></p>

<img src="https://github.com/user-attachments/assets/33d1298c-dddb-4106-9283-8d8ca9b5fb0d" width="300" alt="Visual Studio Code Copilot Üzerindeki Çıktısı">
<p><em>Visual Studio Code Copilot Üzerindeki Çıktısı</em></p>

<div align="right">
<a href="#top">⬆️ Başa dön</a>
</div>
