FROM mcr.microsoft.com/dotnet/core/aspnet
ENV NAME ${PROJECT_NAME}
CMD ["dotnet", "${SOLUTION_DLL_FILE}"]