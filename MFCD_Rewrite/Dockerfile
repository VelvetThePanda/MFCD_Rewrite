FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MFCD_Rewrite/MFCD_Rewrite.csproj", "MFCD_Rewrite/"]
RUN dotnet restore "MFCD_Rewrite/MFCD_Rewrite.csproj"
COPY . .
WORKDIR "/src/MFCD_Rewrite"
RUN dotnet build "MFCD_Rewrite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MFCD_Rewrite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MFCD_Rewrite.dll"]