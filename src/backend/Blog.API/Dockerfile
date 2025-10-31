# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/backend/Blog.API/Blog.API.csproj", "src/backend/Blog.API/"]
COPY ["src/shared/Blog.Comunication/Blog.Comunication.csproj", "src/shared/Blog.Comunication/"]
COPY ["src/backend/Blog.Aplication/Blog.Aplication.csproj", "src/backend/Blog.Aplication/"]
COPY ["Blog.Exception/Blog.Exception.csproj", "Blog.Exception/"]
COPY ["src/backend/Blog.Infra/Blog.Infra.csproj", "src/backend/Blog.Infra/"]
COPY ["src/backend/Bog.Domain/Bog.Domain.csproj", "src/backend/Bog.Domain/"]
RUN dotnet restore "./src/backend/Blog.API/Blog.API.csproj"
COPY . .
WORKDIR "/src/src/backend/Blog.API"
RUN dotnet build "./Blog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Blog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog.API.dll"]