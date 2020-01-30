#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Vlad2020.Apps.Api.Base/Vlad2020.Apps.Api.Base.csproj", "Vlad2020.Apps.Api.Base/"]
COPY ["Vlad2020.Root.Apps.Api.Base/Vlad2020.Root.Apps.Api.Base.csproj", "Vlad2020.Root.Apps.Api.Base/"]
COPY ["Vlad2020.Mods.DummyMain.Base/Vlad2020.Mods.DummyMain.Base.csproj", "Vlad2020.Mods.DummyMain.Base/"]
COPY ["Vlad2020.Data.Entity/Vlad2020.Data.Entity.csproj", "Vlad2020.Data.Entity/"]
COPY ["Vlad2020.Data.Base/Vlad2020.Data.Base.csproj", "Vlad2020.Data.Base/"]
COPY ["Vlad2020.Core.Base/Vlad2020.Core.Base.csproj", "Vlad2020.Core.Base/"]
COPY ["Vlad2020.Mods.Auth.Base/Vlad2020.Mods.Auth.Base.csproj", "Vlad2020.Mods.Auth.Base/"]
COPY ["Vlad2020.Host.Base/Vlad2020.Host.Base.csproj", "Vlad2020.Host.Base/"]
COPY ["Vlad2020.Root.Base/Vlad2020.Root.Base.csproj", "Vlad2020.Root.Base/"]
COPY ["Vlad2020.Core.Data.SqlServer/Vlad2020.Core.Data.SqlServer.csproj", "Vlad2020.Core.Data.SqlServer/"]
COPY ["Vlad2020.Data.Entity.SqlServer/Vlad2020.Data.Entity.SqlServer.csproj", "Vlad2020.Data.Entity.SqlServer/"]
RUN dotnet restore "Vlad2020.Apps.Api.Base/Vlad2020.Apps.Api.Base.csproj"
COPY . .
WORKDIR "/src/Vlad2020.Apps.Api.Base"
RUN dotnet build "Vlad2020.Apps.Api.Base.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vlad2020.Apps.Api.Base.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vlad2020.Apps.Api.Base.dll"]
