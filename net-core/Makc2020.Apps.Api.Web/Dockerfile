#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Vlad2020.Apps.Api.Web/Vlad2020.Apps.Api.Web.csproj", "Vlad2020.Apps.Api.Web/"]
COPY ["Vlad2020.Root.Apps.Api.Web/Vlad2020.Root.Apps.Api.Web.csproj", "Vlad2020.Root.Apps.Api.Web/"]
COPY ["Vlad2020.Data.Caching/Vlad2020.Data.Caching.csproj", "Vlad2020.Data.Caching/"]
COPY ["Vlad2020.Data.Base/Vlad2020.Data.Base.csproj", "Vlad2020.Data.Base/"]
COPY ["Vlad2020.Core.Base/Vlad2020.Core.Base.csproj", "Vlad2020.Core.Base/"]
COPY ["Vlad2020.Core.Caching/Vlad2020.Core.Caching.csproj", "Vlad2020.Core.Caching/"]
COPY ["Vlad2020.Root.Web/Vlad2020.Root.Web.csproj", "Vlad2020.Root.Web/"]
COPY ["Vlad2020.Root.Base/Vlad2020.Root.Base.csproj", "Vlad2020.Root.Base/"]
COPY ["Vlad2020.Core.Data.SqlServer/Vlad2020.Core.Data.SqlServer.csproj", "Vlad2020.Core.Data.SqlServer/"]
COPY ["Vlad2020.Data.Entity.SqlServer/Vlad2020.Data.Entity.SqlServer.csproj", "Vlad2020.Data.Entity.SqlServer/"]
COPY ["Vlad2020.Data.Entity/Vlad2020.Data.Entity.csproj", "Vlad2020.Data.Entity/"]
COPY ["Vlad2020.Host.Base/Vlad2020.Host.Base.csproj", "Vlad2020.Host.Base/"]
COPY ["Vlad2020.Mods.Auth.Web/Vlad2020.Mods.Auth.Web.csproj", "Vlad2020.Mods.Auth.Web/"]
COPY ["Vlad2020.Host.Web/Vlad2020.Host.Web.csproj", "Vlad2020.Host.Web/"]
COPY ["Vlad2020.Core.Web/Vlad2020.Core.Web.csproj", "Vlad2020.Core.Web/"]
COPY ["Vlad2020.Mods.Auth.Base/Vlad2020.Mods.Auth.Base.csproj", "Vlad2020.Mods.Auth.Base/"]
COPY ["Vlad2020.Root.Apps.Api.Base/Vlad2020.Root.Apps.Api.Base.csproj", "Vlad2020.Root.Apps.Api.Base/"]
COPY ["Vlad2020.Mods.DummyMain.Base/Vlad2020.Mods.DummyMain.Base.csproj", "Vlad2020.Mods.DummyMain.Base/"]
COPY ["Vlad2020.Mods.DummyMain.Web/Vlad2020.Mods.DummyMain.Web.csproj", "Vlad2020.Mods.DummyMain.Web/"]
COPY ["Vlad2020.Mods.DummyMain.Caching/Vlad2020.Mods.DummyMain.Caching.csproj", "Vlad2020.Mods.DummyMain.Caching/"]
RUN dotnet restore "Vlad2020.Apps.Api.Web/Vlad2020.Apps.Api.Web.csproj"
COPY . .
WORKDIR "/src/Vlad2020.Apps.Api.Web"
RUN dotnet build "Vlad2020.Apps.Api.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vlad2020.Apps.Api.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vlad2020.Apps.Api.Web.dll"]
