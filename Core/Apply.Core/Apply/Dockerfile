FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Apply.csproj", "./"]
RUN dotnet restore "Apply.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Apply.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Apply.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./CounterPage/build ./wwwroot

RUN useradd -m applyuser
USER applyuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Apply.dll