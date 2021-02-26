#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 30725
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Example.Taxa.WebApi/Example.Taxa.WebApi.csproj", "Example.Taxa.WebApi/"]
COPY ["Example.Infra.CrossCutting.IoC/Example.Infra.CrossCutting.IoC.csproj", "Example.Infra.CrossCutting.IoC/"]
COPY ["Example.Data.Oracle.Nhibernate/Example.Data.Oracle.Nhibernate.csproj", "Example.Data.Oracle.Nhibernate/"]
COPY ["Example.Domain/Example.Domain.csproj", "Example.Domain/"]
COPY ["Example.Domain.Core/Example.Domain.Core.csproj", "Example.Domain.Core/"]
COPY ["Example.Application/Example.Application.csproj", "Example.Application/"]
COPY ["Example.Infra.CrossCutting.Bus/Example.Infra.CrossCutting.Bus.csproj", "Example.Infra.CrossCutting.Bus/"]
RUN dotnet restore "Example.Taxa.WebApi/Example.Taxa.WebApi.csproj"
COPY . .
WORKDIR "/src/Example.Taxa.WebApi"
RUN dotnet build "Example.Taxa.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.Taxa.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.Taxa.WebApi.dll"]