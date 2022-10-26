FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebPlanner/WebPlanner.csproj", "WebPlanner/"]
COPY ["WebPlanner.DAL/WebPlanner.DAL.csproj", "WebPlanner.DAL/"]
COPY ["WebPlanner.Domain/WebPlanner.Domain.csproj", "WebPlanner.Domain/"]
COPY ["WebPlanner.Service/WebPlanner.Service.csproj", "WebPlanner.Service/"]
RUN dotnet restore "WebPlanner/WebPlanner.csproj"
COPY . .
WORKDIR "/src/WebPlanner"
RUN dotnet build "WebPlanner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebPlanner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebPlanner.dll"]