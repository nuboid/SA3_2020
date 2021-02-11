#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ARCH.Mobile.BFF/ARCH.Mobile.BFF.csproj", "ARCH.Mobile.BFF/"]
RUN dotnet restore "ARCH.Mobile.BFF/ARCH.Mobile.BFF.csproj"
COPY . .
WORKDIR "/src/ARCH.Mobile.BFF"
RUN dotnet build "ARCH.Mobile.BFF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ARCH.Mobile.BFF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ARCH.Mobile.BFF.dll"]