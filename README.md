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
   git clone https://github.com/hardy6934/BookHavenWebAPI.git
   cd BookHavenWebAPI
   ```

2. Постройте и запустите контейнеры:

   ```bash
   docker-compose up --build
   ```

   Будут запущены следующие сервисы:

   * 🐘 **PostgreSQL** — порт `5433`
   * 💂 **Adminer** — веб-интерфейс по порту `8082`
   * 🚀 **ASP.NET API** — порт `8080`
   * 🟥 **Redis** — порт `6379`
   * 🧭 **Redisinsight** — порт `8001` 

---

## 💾 Доступ к сервисам

После запуска контейнеров:

* 🔗 [**Adminer**](http://localhost:8082) — подключение к базе данных
* 🔗 [**API (Swagger)**](http://localhost:8080/swagger/index.html) - страница Swagger
* 🔗 [**Redisinsight**](http://localhost:8001) - подключение к Redis

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
* `BookHavenWebAPI.Tests` — Тесты приложения

---

## 🐳 Docker-инфраструктура

| Контейнер       | Назначение             | Порт   |
| --------------- | ---------------------- | ------ |
| `bookhaven-api` | ASP.NET Web API        | `8080` |
| `bookhaven-db`  | PostgreSQL база данных | `5433` |
| `adminer`       | UI для PostgreSQL      | `8082` |
| `Redis`         | Redis база данных      | `6379` |
| `Redisinsight`  | UI для Redis           | `8001` |

---


## 🥈 Миграции EF Core

Миграции применяются автоматически при запуске проекта!


 