FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution file
COPY Ntigra.Ecommerce.Platform.sln .

# Copy services folder (which contains ecommerce/src)
COPY services ./services

# Restore
RUN dotnet restore Ntigra.Ecommerce.Platform.sln

# Publish web project
RUN dotnet publish services/ecommerce/src/Ntigra.Ecommerce.Platform.Web/Ntigra.Ecommerce.Platform.Web.csproj \
    -c Release -o /out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Ntigra.Ecommerce.Platform.Web.dll"]