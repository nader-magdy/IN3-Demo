FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["IN3.Demo.Api/IN3.Demo.Api.csproj", "IN3.Demo.Api/"]
RUN dotnet restore "IN3.Demo.Api/IN3.Demo.Api.csproj"
COPY . .
WORKDIR "/src/IN3.Demo.Api"
RUN dotnet build "IN3.Demo.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IN3.Demo.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IN3.Demo.Api.dll"]