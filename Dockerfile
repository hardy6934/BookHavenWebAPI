# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем sln и csproj файлы
COPY BookHaven.sln ./ 
COPY BookHaven/BookHaven.csproj ./BookHaven/
COPY BookHaven.Buisness/BookHaven.Buisness.csproj ./BookHaven.Buisness/
COPY BookHaven.Core/BookHaven.Core.csproj ./BookHaven.Core/
COPY BookHaven.CQS/BookHaven.CQS.csproj ./BookHaven.CQS/
COPY BookHaven.Database/BookHaven.Database.csproj ./BookHaven.Database/

# Восстанавливаем зависимости
RUN dotnet restore

# Копируем остальные файлы
COPY . .

# Публикуем релизную сборку
WORKDIR /src/BookHaven
RUN dotnet publish -c Release -o /app/publish

# Этап рантайма
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish ./

# Документируем порты
EXPOSE 8080
EXPOSE 8081

# Указываем, на каких портах слушать
ENV ASPNETCORE_URLS=http://+:8080;

ENTRYPOINT ["dotnet", "BookHaven.dll"]