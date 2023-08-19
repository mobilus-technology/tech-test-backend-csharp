FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet tool install --global dotnet-ef --version 7.0.0

ENV PATH="${PATH}:/root/.dotnet/tools"

RUN dotnet ef migrations add InitialMigration

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "WebApiProduct.dll"]
