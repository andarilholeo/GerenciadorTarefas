FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY GerenciadorTarefas.API/*.csproj ./GerenciadorTarefas.API/
COPY GerenciadorTarefas.Infra/*.csproj ./GerenciadorTarefas.Infra/
COPY GerenciadorTarefas.Domain/*.csproj ./GerenciadorTarefas.Domain/
COPY GerenciadorTarefas.Test/*.csproj ./GerenciadorTarefas.Test/

RUN dotnet restore GerenciadorTarefas.API/GerenciadorTarefas.API.csproj

COPY . ./
WORKDIR /app/GerenciadorTarefas.API
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build-env /app/GerenciadorTarefas.API/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "GerenciadorTarefas.API.dll"]