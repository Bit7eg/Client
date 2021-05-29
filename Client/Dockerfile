#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Client.csproj", "Client/"]
RUN dotnet restore "Client/Client.csproj"
WORKDIR "/src/Client"
COPY . .
RUN dotnet build "Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Client.dll"]