FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 3708

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TenderApplicationBackend/TenderApplicationBackend.csproj", "TenderApplicationBackend/"]
RUN dotnet restore "TenderApplicationBackend/TenderApplicationBackend.csproj"
COPY . .
WORKDIR "/src/TenderApplicationBackend"
RUN dotnet build "TenderApplicationBackend.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TenderApplicationBackend.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TenderApplicationBackend.dll"]