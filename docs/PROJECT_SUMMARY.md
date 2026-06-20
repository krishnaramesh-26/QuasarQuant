# QuasarQuant — Project Summary

## Overview

QuasarQuant is a long-term software engineering project that will evolve into a quantitative research, backtesting, machine learning, and paper trading platform.

It is designed primarily as a learning and portfolio project, focused on building real-world experience in:

- Backend Engineering
- Frontend Development
- System Design
- Databases (SQL)
- DevOps & CI/CD
- Cybersecurity fundamentals
- Machine Learning Engineering
- Distributed systems concepts

The goal is not to build a profitable trading system, but to build a scalable engineering platform for experimenting with trading strategies and ML models.

---

## Core Idea

Users will be able to:

- Register and authenticate
- View historical market data
- Run trading strategies
- Backtest strategies on historical data
- Simulate paper trading
- Track portfolio performance
- Receive ML-based trading signals
- Compare strategy performance over time

---

## Tech Stack

### Frontend
- Blazor Server (C#)

### Backend
- ASP.NET Core Web API (C#)

### Machine Learning Service
- Python
- FastAPI
- scikit-learn (initially)
- TensorFlow (later)

### Database
- PostgreSQL

Used as the system of record for:
- Users
- Portfolios
- Trades
- Market data
- Backtests

### Cache Layer
- Redis

Used for:
- Market data caching
- Backtest result caching
- ML prediction caching
- Rate limiting
- Session/state optimisation

### Infrastructure
- Docker
- Docker Compose
- GitHub Actions (CI/CD)
- Linux VPS (future deployment)
- Nginx (future reverse proxy)



## High-Level Architecture

    Blazor Frontend (QuasarQuant.Web)  
                    ↓  
    ASP.NET Core API (QuasarQuant.API)  
                    ↓
    ---------------------------------------------------
        ↓             ↓            ↓                 ↓  
    PostgreSQL      Redis       Python ML      External APIs  
                                Service  


### Blazor Frontend (QuasarQuant.Web)

Handles UI, dashboards, charts, and user interaction.

### ASP.NET Core API (QuasarQuant.API)

Core backend system handling:
- Authentication
- Portfolio logic
- Backtesting orchestration
- Communication with database, Redis, and ML service

### PostgreSQL

Source of truth database storing:
- Users
- Trades
- Portfolios
- Historical market data
- Backtest results

### Redis

High-speed caching layer for:
- Stock price caching
- Backtest result caching
- ML prediction caching
- Rate limiting

### Python ML Service (FastAPI)

Independent service responsible for:
- Training ML models
- Generating predictions (BUY / SELL / HOLD)
- Feature engineering

### External APIs

Data sources such as:
- Yahoo Finance
- Market data providers

---


## Machine Learning Service (Detailed)

The ML component is fully separated from the .NET system and implemented as a standalone Python service.

It is responsible for:
- Training models on historical market data
- Running inference (generating predictions)
- Managing feature engineering pipelines
- Versioning and storing trained models

---

### Frameworks & Libraries

The ML service will use the following Python ecosystem:

#### Core ML / Data Stack
- **pandas** → data manipulation and feature engineering  
- **numpy** → numerical computation  
- **scikit-learn** → baseline machine learning models  
- **TensorFlow / Keras (later stage)** → deep learning models  
- **ta (Technical Analysis library)** → financial indicators (RSI, MACD, moving averages)

#### API Layer
- **FastAPI** → serving ML predictions via REST endpoints  
- **uvicorn** → ASGI server for running the service  

#### Experimentation & Development (optional but recommended)
- **Jupyter Notebooks** → research and experimentation  
- **matplotlib / plotly** → visualisation of strategies and model performance  

---

### ML Models (Initial Approach)

Version 1 will focus on simple, interpretable models:

- Logistic Regression (baseline directional prediction)
- Random Forest Classifier
- Gradient Boosted Trees (optional extension)

These models will predict:
- BUY / SELL / HOLD signals
- Probability/confidence score

Deep learning models (LSTMs, Transformers) are intentionally deferred until the data pipeline and feature engineering system is stable.

---

### Feature Engineering Pipeline

Raw market data will be transformed into features such as:

- Moving averages (SMA, EMA)
- RSI (Relative Strength Index)
- MACD (Moving Average Convergence Divergence)
- Price returns (daily/weekly % change)
- Volatility measures
- Volume-based indicators

These features are generated using:
- pandas transformations
- technical analysis libraries (ta)

---

### Training Pipeline Design

The training process will follow a structured pipeline:

1. Data ingestion from PostgreSQL (historical prices)
2. Feature engineering step (Python pipeline)
3. Train/test split based on time series (no random shuffling)
4. Model training using scikit-learn
5. Evaluation using:
   - Accuracy (direction prediction)
   - Precision/Recall
   - Backtested strategy performance (most important metric)
6. Model persistence

---

### Model Storage & Versioning

Trained models will be stored using:

- **joblib** (for scikit-learn models)
- Optional later: **TensorFlow SavedModel format**

Models will be versioned as:

```
/ml-models/
    /random_forest_v1.pkl
    /logistic_regression_v1.pkl
    /xgboost_v2.pkl
````

Each model version will include:

* Training dataset window
* Feature set definition
* Hyperparameters
* Evaluation metrics

---

### ML Inference Flow

The runtime prediction flow will be:

```
ASP.NET API
      ↓
FastAPI ML Service
      ↓
Feature generation
      ↓
Loaded trained model
      ↓
Prediction (BUY / SELL / HOLD + confidence)
      ↓
Return response to backend
```

---

### Pipeline Storage Strategy (Important Design Decision)

To keep the system reproducible and scalable:

* **PostgreSQL** stores:

  * raw market data
  * training datasets metadata
  * backtest results

* **File-based storage (initially)** stores:

  * trained ML models
  * feature pipeline definitions

* Future upgrade (optional):

  * MLflow for experiment tracking
  * model registry
  * automated retraining pipelines

---

### Long-Term Evolution (Out of MVP Scope)

Later versions may introduce:

* LSTM / Transformer models for sequence prediction
* Reinforcement learning for strategy optimization
* MLflow for experiment tracking
* Airflow / Prefect for scheduled retraining pipelines
* Real-time streaming features (Kafka-style ingestion)

These are intentionally deferred until the core system is stable.

