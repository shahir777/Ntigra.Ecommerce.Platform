# Ntigra Ecommerce Platform

## 📌 Overview
This project is a simple **Online Shopping Web Application** developed using **ASP.NET Core MVC** as part of a technical assessment.  
The application demonstrates clean architecture, Domain-Driven Design (DDD), proper separation of concerns, and containerized deployment using Docker.

---

## 🏗 Architecture & Design

The solution follows **Clean Architecture** and **Domain-Driven Design (DDD)** principles.

### Layered Structure
├── Web (Presentation Layer)
│ └── MVC Controllers & Razor Views
│
├── Application
│ └── Application services, DTOs, interfaces
│
├── Domain
│ └── Core business entities, domain logic, pricing rules
│
├── Infrastructure
│ └── EF Core, repositories, database configurations

### Key Design Principles
- **Domain layer is fully independent** of other layers
- **All business logic resides in the Domain layer**
- **Dependency Injection** used across the application
- **Loose coupling** between layers via interfaces
- **Single Responsibility Principle** followed consistently

# ⚙️ Technology Stack

- **Framework:** ASP.NET Core MVC (.NET 8)
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **UI:** Razor Views + Bootstrap
- **Containerization:** Docker & Docker Compose
- **Logging:** `ILogger` with custom extensions

## ✅ Implemented Features

### Backend
- Product listing with:
  - Name
  - Description
  - Price
  - Discount percentage
- Cart management:
  - Add / Remove products
  - Quantity handling
- Discount logic:
  - Applied only when cart total crosses a defined threshold
  - Per-product discount calculation
  - Business rules handled inside Domain layer
- Centralized error handling using **custom exception classes**
- Standardized response handling using **custom response models**
- Request validation and domain validation

### Frontend
- Consistent UI theme inspired by **Ntigra’s official website**
- Responsive and user-friendly layout
- UI behavior driven by controller responses
- Clean and simple shopping flow

## 🧮 Discount Logic (Business Rule)

- Discount is applied **only if total cart value exceeds a threshold**
- Discount is calculated **per product**
- All pricing and discount calculations are implemented in the **Domain layer**
- Application layer only orchestrates and maps results

## 🐳 Running the Application (Docker)

The application is fully containerized.  
**No local database or SQL Server installation is required.**

### Prerequisites
- Docker Desktop
- Docker Compose

### Run Command
From the solution root:
```bash
docker compose up --build