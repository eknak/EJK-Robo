#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EJK.Robos.ComprasNet.Mensagens/EJK.Robos.ComprasNet.Mensagens.csproj", "EJK.Robos.ComprasNet.Mensagens/"]
RUN dotnet restore "EJK.Robos.ComprasNet.Mensagens/EJK.Robos.ComprasNet.Mensagens.csproj"
COPY . .
WORKDIR "/src/EJK.Robos.ComprasNet.Mensagens"
RUN dotnet build "EJK.Robos.ComprasNet.Mensagens.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EJK.Robos.ComprasNet.Mensagens.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EJK.Robos.ComprasNet.Mensagens.dll"]