#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["POS_System/POS_System.csproj", "POS_System/"]
COPY ["PL/PL.csproj", "PL/"]
COPY ["BLL/BLL.csproj", "BLL/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["DTO/DTO.csproj", "DTO/"]
RUN dotnet restore "POS_System/POS_System.csproj"
COPY . .
WORKDIR "/src/POS_System"
RUN dotnet build "POS_System.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POS_System.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POS_System.dll"]