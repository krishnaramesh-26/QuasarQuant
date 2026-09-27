# QuasarQuant

QuasarQuant is a learning and portfolio project for building a quantitative research, backtesting, machine learning, and paper-trading platform. The goal is to build a maintainable engineering platform, not to promise profitable trading results.

## Documentation

Start with the guide that matches the question you are asking:

| Question | Document |
|---|---|
| What belongs in the first release? | [MVP](docs/MVP.md) |
| Which HTTP routes exist? | [API Endpoints](docs/API_ENDPOINTS.md) |
| How do the services and containers fit together? | [Backend Infrastructure](docs/BACKEND_INFRASTRUCTURE.md) |
| Where does use-case logic belong? | [Application Services](docs/APPLICATION_SERVICES.md) |
| How should storage be accessed? | [Repositories and Data Access](docs/REPOSITORIES_AND_DATA_ACCESS.md) |
| How will the Python ML service work? | [ML Service](docs/ML_SERVICE.md) |
| How do I run the project locally? | [Local Development](docs/LOCAL_DEVELOPMENT.md) |

## Current stack

- Blazor Server frontend (`QuasarQuant.Web`)
- ASP.NET Core Web API (`QuasarQuant.API`)
- PostgreSQL for planned durable storage
- Redis for planned caching
- Python and FastAPI for the planned ML service
- Docker Compose for local multi-service development

The current API uses an in-memory signal repository so the request flow can be developed before PostgreSQL is connected.
