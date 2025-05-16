# 📚 BookHaven — Онлайн-магазин книг

Это веб-приложение на ASP.NET Core для управления книжным магазином.
**Технологии:** `ASP.NET Core`, `Entity Framework Core`, `PostgreSQL`, `Docker`, `Adminer`, `CQS`

---

## 🚀 Запуск проекта

### 📦 Требования

* [Docker](https://www.docker.com/)
* [Docker Compose](https://docs.docker.com/compose/)

### ⚙️ Инструкция по запуску

1. Склонируйте репозиторий:

   ```bash
   git clone https://github.com/your-username/bookhaven.git
   cd bookhaven
   ```

2. Постройте и запустите контейнеры:

   ```bash
   docker-compose up --build
   ```

   Будут запущены следующие сервисы:

   * 🐘 **PostgreSQL** — порт `5433`
   * 💂 **Adminer** — веб-интерфейс по порту `8082`
   * 🚀 **ASP.NET API** — порт `8080`

---

## 💾 Доступ к сервисам

После запуска контейнеров:

* 🔗 [**Adminer**](http://localhost:8082) — подключение к базе данных
* 🔗 [**API (Swagger, если есть)**](http://localhost:8080/swagger/index.html)

**Параметры подключения к Adminer:**

* **System**: PostgreSQL
* **Server**: `postgres`
* **Username**: `postgres`
* **Password**: `1234`
* **Database**: `bookhaven_db`

---

## 📊 Функциональность API

### 👤 Пользователи

* Регистрация и аутентификация
* Обновление данных и токенов

### 📘 Книги

* Получение всех книг
* Добавление и редактирование
* Поиск по жанрам и коллекциям

### 📂 Коллекции и жанры

* Создание коллекций и жанров
* Связь книг с коллекциями
* Фильтрация по жанру

---

## 🧱 Архитектура проекта

### 📂 Проект состоит из следующих модулей:

* `BookHavenWebAPI` — основной Web API
* `BookHavenWebAPI.Core` — бизнес-сущности
* `BookHavenWebAPI.CQS` — команды и запросы
* `BookHavenWebAPI.Buisness` — реализация бизнес-логики
* `BookHavenWebAPI.DataBase` — миграции и конфигурации EF Core

---

## 🐳 Docker-инфраструктура

| Контейнер       | Назначение             | Порт   |
| --------------- | ---------------------- | ------ |
| `bookhaven-api` | ASP.NET Web API        | `8080` |
| `bookhaven-db`  | PostgreSQL база данных | `5433` |
| `adminer`       | UI для PostgreSQL      | `8082` |

---

## ⚙️ Конфигурация подключения к БД (Docker)

```env
ConnectionStrings__Default=Host=postgres;Port=5432;Database=bookhaven_db;Username=postgres;Password=1234
```

⚠️ Обратите внимание: в `docker-compose.yml` PostgreSQL маппится на порт `5433` хоста, но **внутри контейнеров** он остаётся `5432`, поэтому `Host=postgres:5432` внутри API — корректно.

---

## 🥈 Миграции EF Core

Миграции применяются автоматически при запуске `BookHavenContext`:

```csharp 
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BookHavenContext>();
    db.Database.Migrate();
}
```

---

## 📌 Полезные команды

Создание новой миграции:

```bash
dotnet ef migrations add InitialCreate -p BookHavenWebAPI.DataBase -s BookHavenWebAPI
```

Применение миграций:

```bash
dotnet ef database update -p BookHavenWebAPI.DataBase -s BookHavenWebAPI
```

---

## 🛠️ Автор

Разработано с ❤️ для дипломного проекта.
Контакт: \[ваш email / GitHub / Telegram]
