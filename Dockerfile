FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /usr/app
COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /usr/app/out .
#CMD [ "ping", "google.com" ]
ENTRYPOINT ["dotnet", "AcademyProject.dll"]

