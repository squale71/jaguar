FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Jaguar/Jaguar.csproj", "Jaguar/"]
RUN dotnet restore "Jaguar/Jaguar.csproj"
COPY . .
WORKDIR "/src/Jaguar"
RUN dotnet build "Jaguar.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Jaguar.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Jaguar.dll"]
