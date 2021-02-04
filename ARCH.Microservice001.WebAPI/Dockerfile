#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ARCH.Microservice001.WebAPI/ARCH.Microservice001.WebAPI.csproj", "ARCH.Microservice001.WebAPI/"]
RUN dotnet restore "ARCH.Microservice001.WebAPI/ARCH.Microservice001.WebAPI.csproj"
COPY . .
WORKDIR "/src/ARCH.Microservice001.WebAPI"
RUN dotnet build "ARCH.Microservice001.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ARCH.Microservice001.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ARCH.Microservice001.WebAPI.dll"]