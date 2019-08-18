FROM mcr.microsoft.com/dotnet/core/sdk

COPY HttpApi/bin/Debug/netcoreapp2.1/publish .

WORKDIR .

EXPOSE 8080

ENTRYPOINT ["dotnet", "HttpApi.dll"]