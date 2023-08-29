#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Organization.TodoApp.API/Organization.TodoApp.API.csproj", "src/Organization.TodoApp.API/"]
RUN dotnet restore "src/Organization.TodoApp.API/Organization.TodoApp.API.csproj"
COPY . .
WORKDIR "/src/src/Organization.TodoApp.API"
RUN dotnet build "Organization.TodoApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Organization.TodoApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Organization.TodoApp.API.dll"]