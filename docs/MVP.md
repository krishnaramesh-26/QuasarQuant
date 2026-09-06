# Minimum Viable Product

## Purpose

The MVP is the smallest useful version of QuasarQuant. It should demonstrate a complete path from market data and strategy logic to a visible result without introducing infrastructure that the project does not yet need.

## MVP goals

- Run the ASP.NET Core API and Blazor Web application locally.
- Expose a documented health endpoint and signal endpoints.
- Represent trading signals with a stable core model.
- Support an in-memory repository while the persistence model is designed.
- Store and retrieve the first durable records in PostgreSQL.
- Display signal and basic portfolio information in the web application.
- Establish a small Python ML service contract for prediction experiments.
- Add automated builds and focused tests for the main request paths.

## MVP user capabilities

Users should eventually be able to:

- Register and authenticate.
- View historical market data.
- View generated trading signals.
- Run a strategy against historical data.
- Review a basic backtest result.
- Simulate paper trades.
- Track portfolio value and performance.

These capabilities are product goals; endpoint and implementation details belong in the linked technical documents.

## Out of scope for the first release

- Live trading with real money.
- High-frequency or low-latency trading.
- Deep learning before the baseline data pipeline is reliable.
- Reinforcement learning.
- Kafka-style streaming infrastructure.
- Kubernetes or a microservice fleet.
- Automated retraining orchestration.
- A production-grade model registry before model versioning needs it.

## Delivery order

1. Keep the API and web app compiling and runnable.
2. Finish the signal request flow with tests.
3. Add PostgreSQL persistence behind repository interfaces.
4. Add authentication and user-owned portfolios.
5. Add historical market data and a simple backtest.
6. Add the Python prediction service behind an explicit API contract.
7. Add CI/CD and deployment only after local behavior is stable.

## Scope boundaries

- Product scope and priorities belong in this document.
- HTTP routes and payloads belong in [API Endpoints](API_ENDPOINTS.md).
- Runtime components and deployment belong in [Backend Infrastructure](BACKEND_INFRASTRUCTURE.md).
- Python model and feature-pipeline decisions belong in [ML Service](ML_SERVICE.md).
