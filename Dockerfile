FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview7 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-preview7-disco
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "bouvet-ctf.dll"]