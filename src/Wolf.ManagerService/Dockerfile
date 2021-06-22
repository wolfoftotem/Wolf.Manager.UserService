FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 7000
ENV LANG="zh_CN.UTF-8"
ENV TZ=Asia/Shanghai

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet nuget list source
RUN dotnet nuget add source https://nuget.pkg.github.com/wolfoftotem/index.json -n github -u wolfoftotem -p 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 --store-password-in-clear-text
RUN dotnet restore "src/Wolf.ManagerService/Wolf.ManagerService.csproj"
RUN dotnet build "src/Wolf.ManagerService/Wolf.ManagerService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "src/Wolf.ManagerService/Wolf.ManagerService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet","Wolf.ManagerService.dll"]

