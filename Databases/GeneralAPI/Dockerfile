# 

FROM mcr.microsoft.com/mssql/server:2019-latest AS build
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Password1
ENV MSSQL_PID=Developer
ENV MSSQL_TCP_PORT=1433

WORKDIR /src
COPY seeddb.sql ./seeddb.sql

# ALL PASSWORDS AND USERNAMES SHOULD NOT BE STORED IN THIS DOCKERFILE. ALWAYS STORES THESE VARS IN A SECURE STORE
RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" &&  /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P Password1 -i seeddb.sql