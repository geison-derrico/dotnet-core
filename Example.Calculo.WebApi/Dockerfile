#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY ["Example.Calculo.WebApi/Example.Calculo.WebApi.csproj", "Example.Calculo.WebApi/"]
COPY ["Example.Infra.CrossCutting.IoC/Example.Infra.CrossCutting.IoC.csproj", "Example.Infra.CrossCutting.IoC/"]
COPY ["Example.Data.Oracle.Nhibernate/Example.Data.Oracle.Nhibernate.csproj", "Example.Data.Oracle.Nhibernate/"]
COPY ["Example.Domain/Example.Domain.csproj", "Example.Domain/"]
COPY ["Example.Domain.Core/Example.Domain.Core.csproj", "Example.Domain.Core/"]
COPY ["Example.Application/Example.Application.csproj", "Example.Application/"]
COPY ["Example.Infra.CrossCutting.Bus/Example.Infra.CrossCutting.Bus.csproj", "Example.Infra.CrossCutting.Bus/"]
RUN dotnet restore "Example.Calculo.WebApi/Example.Calculo.WebApi.csproj"
COPY . .
WORKDIR "/src/Example.Calculo.WebApi"
RUN dotnet build "Example.Calculo.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.Calculo.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.Calculo.WebApi.dll"]