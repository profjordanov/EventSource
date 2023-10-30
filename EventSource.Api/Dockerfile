FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EventSource.Api/EventSource.Api.csproj", "EventSource.Api/"]
COPY ["EventSource.Persistence/EventSource.Persistence.csproj", "EventSource.Persistence/"]
COPY ["EventSource.Domain/EventSource.Domain.csproj", "EventSource.Domain/"]
RUN dotnet restore "EventSource.Api/EventSource.Api.csproj"
COPY . .
WORKDIR /src/EventSource.Api
RUN dotnet build "EventSource.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventSource.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventSource.Api.dll"]