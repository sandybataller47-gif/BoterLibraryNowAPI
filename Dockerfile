FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=https//+:8080

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /src
COPY . .
RUN dotnet restore "BoterLibraryNowAPI.csproj"
RUN dotnet publish -c Release -o /app/out


FROM base AS final
WORKDIR /app
COPY __from=build /app/out
ENTRYPOINT ["dotnet","BoterLibraryNowAPI.dll"]s


