# ABC Pharmacy Management

A Single Page Application developed using ASP.NET Core Web API and React.

## Technology Stack

- ASP.NET Core 8 Web API
- React (JavaScript)
- JSON File Storage
- REST API

## Features

- View Medicines
- Add Medicine
- Search Medicines by Name
- Expiry Alert (Red Row)
- Low Stock Alert (Yellow Row)
- JSON File Persistence

## Project Structure

PharmacyManagement
│
├── src
│   ├── PharmacyApi
│   └── PharmacyUI
│
└── tests
    ├── PharmacyApi.Tests
    └── PharmacyUI.Tests

## Run Backend

```bash
cd src/PharmacyApi
dotnet run
```

## Run Frontend

```bash
cd src/PharmacyUI
npm install
npm start
```

Backend:
http://localhost:5071

Frontend:
http://localhost:3000