#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Vlad2020.Apps.Automation.Base/Vlad2020.Apps.Automation.Base.csproj", "Vlad2020.Apps.Automation.Base/"]
COPY ["Vlad2020.Root.Apps.Automation.Base/Vlad2020.Root.Apps.Automation.Base.csproj", "Vlad2020.Root.Apps.Automation.Base/"]
COPY ["Vlad2020.Mods.Automation.Base/Vlad2020.Mods.Automation.Base.csproj", "Vlad2020.Mods.Automation.Base/"]
COPY ["Vlad2020.Core.Base/Vlad2020.Core.Base.csproj", "Vlad2020.Core.Base/"]
COPY ["Vlad2020.Host.Base/Vlad2020.Host.Base.csproj", "Vlad2020.Host.Base/"]
COPY ["Vlad2020.Root.Base/Vlad2020.Root.Base.csproj", "Vlad2020.Root.Base/"]
RUN dotnet restore "Vlad2020.Apps.Automation.Base/Vlad2020.Apps.Automation.Base.csproj"
COPY . .
WORKDIR "/src/Vlad2020.Apps.Automation.Base"
RUN dotnet build "Vlad2020.Apps.Automation.Base.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vlad2020.Apps.Automation.Base.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vlad2020.Apps.Automation.Base.dll"]
