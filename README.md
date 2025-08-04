# ZEYNEPKONYALIOGLU KITAPUYGULAMASI

Basit bir kitap satış sistemi RESTful API demo uygulamasıdır. .NET 7, Entity Framework Core, MediatR (CQRS), JWT Authentication, Swagger ve xUnit kullanılarak geliştirilmiştir.

## Ön Koşullar

* .NET 7+ SDK
* SQL Server veya SQL Server LocalDB

## Kurulum ve Çalıştırma

1. **ZIP’i açın**

   * İndirdiğiniz `BookStoreDemoFull.zip` dosyasını bir klasöre çıkartın.

2. **Uygulama klasörüne gidin**

   ```bash
   cd BookStoreDemoFull/BookStore.Api
   ```

3. **Konfigürasyon dosyasını oluşturun**

   ```bash
   cp appsettings.json.example appsettings.json
   # Windows PowerShell:
   # Copy-Item appsettings.json.example appsettings.json
   ```

4. **`appsettings.json` içindeki bağlantı dizesini güncelleyin**

   ```jsonc
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=BookStoreDb;Trusted_Connection=True;"
     },
     "JwtSettings": {
       "Issuer": "BookStoreApi",
       "Audience": "BookStoreClient",
       "Secret": "SuperSecretKey123456"
     }
   }
   ```

5. **NuGet paketlerini yükleyin & Migration’ları uygulayın**

   ```bash
   dotnet restore
   dotnet tool install --global dotnet-ef   # sadece ilk sefer
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

6. **API’yi çalıştırın**

   ```bash
   dotnet run
   ```

7. **API Testi**

   * **Swagger UI:** `http://localhost:5000/swagger`
   * **Auth Endpoint’leri:**

     * `POST /api/auth/register`
     * `POST /api/auth/login`
   * **Kitap CRUD Endpoint’leri:**

     * `GET    /api/books`
     * `GET    /api/books/{id}`
     * `POST   /api/books`  (örnek Body: `{ "title": "Deneme", "author": "Yazar", "categoryId": 1 }`)
     * `PUT    /api/books/{id}`
     * `DELETE /api/books/{id}`

8. **Testleri Çalıştırma**

   ```bash
   cd ../BookStore.Tests
   dotnet test
   ```

---

Bu adımları tamamladığınızda, ZIP içindeki tam çalışan demo API’yi uçtan uca test etmiş olacaksınız.
