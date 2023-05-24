# Docker tutorial followed https://www.youtube.com/watch?v=3s-RfwvijpY
# 
# 
# 


# 1. Build stage

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./isk.GeneralAPI/isk.GeneralAPI.csproj"
RUN dotnet publish "./isk.GeneralAPI/isk.GeneralAPI.csproj" -c release -o /app --no-restore

# 2. Application serve stage

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "isk.GeneralAPI.dll"]