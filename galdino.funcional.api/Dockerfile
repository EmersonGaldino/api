#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat



FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["galdino.funcional.api/galdino.funcional.api.csproj", "galdino.funcional.api/"]
COPY ["galdino.funcional.utils/galdino.funcional.utils.csproj", "galdino.funcional.utils/"]
COPY ["galdino.funcional.domain.shared/galdino.funcional.domain.shared.csproj", "galdino.funcional.domain.shared/"]
COPY ["galdino.funcional.data.persistence/galdino.funcional.data.persistence.csproj", "galdino.funcional.data.persistence/"]
COPY ["galdino.funcional.core/galdino.funcional.domain.core.csproj", "galdino.funcional.core/"]
COPY ["galdino.funcional.application_2/galdino.funcional.application.csproj", "galdino.funcional.application_2/"]
RUN dotnet restore "galdino.funcional.api/galdino.funcional.api.csproj"
COPY . .
WORKDIR "/src/galdino.funcional.api"
RUN dotnet build "galdino.funcional.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "galdino.funcional.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "galdino.funcional.api.dll"]