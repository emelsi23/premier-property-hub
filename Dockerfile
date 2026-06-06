FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["ApartamentosRenta.csproj", "./"]
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

EXPOSE 8080

ENV DOTNET_EnableDiagnostics=0

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ApartamentosRenta.dll"]
