FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["../Requests/Requests.API/Requests.API.csproj", "Requests.API/"]
RUN dotnet restore "../Requests/Requests.API/Requests.API.csproj"
COPY . .
WORKDIR "/src/Requests.API"
RUN dotnet build "Requests.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Requests.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Requests.API.dll"]
