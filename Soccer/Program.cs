using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Soccer.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Отримуємо рядок підключення з файлу конфігурації
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
if (connection != null)
{
    builder.Services.AddSoccerContext(connection);
}
builder.Services.AddUnitOfWorkService();
builder.Services.AddPlayerService();
builder.Services.AddTeamService();
builder.Services.AddSoccerAutoMapper();

builder.Services.AddControllers();

// OpenAPI (раніше відомий як Swagger) — це загальноприйнятий галузевий
// стандарт для опису RESTful Web API.
builder.Services.AddOpenApi();
// Метод AddOpenApi() сканує контролери, аналізує маршрути, параметри,
// моделі даних і HTTP-методи. На основі цього він автоматично формує
// стандартизований опис вашого API (зазвичай у форматі JSON).

var app = builder.Build();

// Налаштування конвеєра HTTP-запитів.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // створює HTTP-маршрут (ендпоінт), за яким застосунок
                      // віддає згенеровану специфікацію OpenAPI у форматі JSON.
                      // https://localhost:7028/openapi/v1.json

    app.MapScalarApiReference(); // завантажує цей JSON-файл і будує на його основі
                                 // сучасний візуальний інтерфейс Scalar
                                 // для взаємодії з Web API-сервісом.
                                 // Інтерфейс для тестування Web API доступний за адресою:
                                 // https://localhost:7028/scalar/v1
}

app.UseStaticFiles(); // дозволяє застосунку ASP.NET Core обслуговувати статичні файли
                      // (наприклад, HTML, CSS, JavaScript або зображення) зазвичай із wwwroot

app.UseHttpsRedirection(); // перенаправляє всі незахищені HTTP-запити на безпечний протокол HTTPS
                           // Це гарантує, що весь трафік між клієнтом і сервером буде зашифрований.
                           // У сучасній розробці це є обов'язковим стандартом, щоб уникнути перехоплення даних.

app.MapControllers(); // відповідає за налаштування маршрутизації (routing) на основі атрибутів для API-контролерів.

app.Run();