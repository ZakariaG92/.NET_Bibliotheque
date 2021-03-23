FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8090
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.csproj", "./"]
RUN dotnet restore "ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.dll"]
