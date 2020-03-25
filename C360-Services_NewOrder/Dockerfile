#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY C360-Services_NewOrder/C360-Services_NewOrder.csproj C360-Services_NewOrder/
RUN dotnet restore "C360-Services_NewOrder/C360-Services_NewOrder.csproj"
COPY . .
WORKDIR "/src/C360-Services_NewOrder"
RUN dotnet build "C360-Services_NewOrder.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "C360-Services_NewOrder.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "C360-Services_NewOrder.dll"]
