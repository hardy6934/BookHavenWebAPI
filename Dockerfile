# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0.200 AS build

WORKDIR /src

# Копируем sln и csproj файлы
COPY BookHavenWebAPI.sln ./ 
COPY BookHavenWebAPI/BookHavenWebAPI.csproj ./BookHavenWebAPI/
COPY BookHavenWebAPI.Buisness/BookHavenWebAPI.Buisness.csproj ./BookHavenWebAPI.Buisness/
COPY BookHavenWebAPI.Core/BookHavenWebAPI.Core.csproj ./BookHavenWebAPI.Core/
COPY BookHavenWebAPI.CQS/BookHavenWebAPI.CQS.csproj ./BookHavenWebAPI.CQS/
COPY BookHavenWebAPI.DataBase/BookHavenWebAPI.DataBase.csproj ./BookHavenWebAPI.DataBase/
COPY BookHavenWebAPI.Tests/BookHavenWebAPI.Tests.csproj ./BookHavenWebAPI.Tests/

# Восстанавливаем зависимости
RUN dotnet restore

# Копируем остальные файлы
COPY . .
 
# Публикуем релизную сборку
WORKDIR /src/BookHavenWebAPI
RUN dotnet publish -c Release -o /app/publish

# Этап рантайма
FROM mcr.microsoft.com/dotnet/aspnet:9.0.2 AS final
WORKDIR /app
COPY --from=build /app/publish ./

# Документируем порты
EXPOSE 8080
EXPOSE 8081

# Указываем, на каких портах слушать
ENV ASPNETCORE_URLS=http://+:8080;

ENTRYPOINT ["dotnet", "BookHavenWebAPI.dll"]
