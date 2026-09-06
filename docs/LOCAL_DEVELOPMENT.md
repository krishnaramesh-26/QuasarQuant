# Local Development

## Run the API

```bash
dotnet run --project src/QuasarQuant.API/QuasarQuant.API.csproj
```

The API launch profiles use `http://localhost:5272` and `https://localhost:7154`.

## Run the web app

In a second terminal:

```bash
dotnet run --project src/QuasarQuant.Web/QuasarQuant.Web.csproj
```

The Web launch profiles use `http://localhost:5013` and `https://localhost:7181`.

The Web app and API are separate processes. The Web app does not yet call the API automatically.

## Build the solution

```bash
dotnet build QuasarQuant.slnx
```

## Run with Docker Compose

```bash
docker compose up --build
```

Compose starts the API, Web app, and PostgreSQL container. See [Backend Infrastructure](BACKEND_INFRASTRUCTURE.md) for the component diagram and service responsibilities.

## Current test data

The API uses `InMemorySignalRepository` while persistence is being built. `AAPL` and `MSFT` return sample signals; unknown symbols return `404 Not Found`.

See [API Endpoints](API_ENDPOINTS.md) for request examples and response behavior.
