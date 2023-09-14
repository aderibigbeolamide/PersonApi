# Use the official ASP.NET Core runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official ASP.NET Core SDK image to build your application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PersonApi.csproj", "PersonApi/"]
RUN dotnet restore "PersonApi/PersonApi.csproj"
COPY . .
WORKDIR "/src/PersonApi"
# Clean the project
RUN dotnet clean
RUN dotnet build "PersonApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonApi.dll"]
