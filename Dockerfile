FROM mcr.microsoft.com/dotnet/sdk:6.0 as builder
WORKDIR /app

COPY  ./Ayo.sln ./
COPY  ./src/Ayo.Api/*.csproj ./src/Ayo.Api/
COPY  ./src/Ayo.Core/*.csproj ./src/Ayo.Core/
COPY  ./tests/Ayo.Core.Tests/*.csproj ./tests/Ayo.Core.Tests/
RUN dotnet restore


COPY . ./
RUN dotnet build -c Release
RUN dotnet test -c Release --no-build
RUN dotnet publish -c Release -o published --no-restore ./src/Ayo.Api


# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0.8 as runtime
WORKDIR /app
COPY --from=builder /app/published .

ARG PORT=80
ENV ASPNETCORE_URLS="http://+:${PORT}"

CMD ["dotnet", "Ayo.Api.dll"]

EXPOSE ${PORT}

ARG VERSION=0.0.1
ENV BUILDNUMBER=${VERSION}