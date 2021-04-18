#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CrunchyPeanutButter.Web/CrunchyPeanutButter.Web.csproj", "CrunchyPeanutButter.Web/"]
COPY ["CrunchyPeanutButter.Application/CrunchyPeanutButter.Application.csproj", "CrunchyPeanutButter.Application/"]
COPY ["CrunchyPeanutButter.Domain/CrunchyPeanutButter.Domain.csproj", "CrunchyPeanutButter.Domain/"]
COPY ["CrunchyPeanutButter.Persistence/CrunchyPeanutButter.Persistence.csproj", "CrunchyPeanutButter.Persistence/"]
COPY ["CrunchyPeanutButter.Infrastructure/CrunchyPeanutButter.Infrastructure.csproj", "CrunchyPeanutButter.Infrastructure/"]
RUN dotnet restore "CrunchyPeanutButter.Web/CrunchyPeanutButter.Web.csproj"
COPY . .
WORKDIR "/src/CrunchyPeanutButter.Web"
RUN dotnet build "CrunchyPeanutButter.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CrunchyPeanutButter.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrunchyPeanutButter.Web.dll"]