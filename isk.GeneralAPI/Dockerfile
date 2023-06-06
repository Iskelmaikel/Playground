# Docker tutorial followed https://www.youtube.com/watch?v=3s-RfwvijpY
# 
# 
# 


# 1. Build stage

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

# 1.1 Set environment variables
# Ensure we listen on any IP Address 
ENV DOTNET_URLS=http://+:5000
ENV ASPNETCORE_HTTP_PORT=https://+:5001

WORKDIR /source
COPY . .
RUN dotnet restore "./isk.GeneralAPI.csproj"
RUN dotnet publish "./isk.GeneralAPI.csproj" -c release -o /app --no-restore

# 2. Application serve stage

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "isk.GeneralAPI.dll"]