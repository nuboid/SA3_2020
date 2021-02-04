#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ARCH.BFF.ForMobileApp1/ARCH.BFF.ForMobileApp1.csproj", "ARCH.BFF.ForMobileApp1/"]
RUN dotnet restore "ARCH.BFF.ForMobileApp1/ARCH.BFF.ForMobileApp1.csproj"
COPY . .
WORKDIR "/src/ARCH.BFF.ForMobileApp1"
RUN dotnet build "ARCH.BFF.ForMobileApp1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ARCH.BFF.ForMobileApp1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ARCH.BFF.ForMobileApp1.dll"]