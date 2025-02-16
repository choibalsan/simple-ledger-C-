# Ledger API

This **.NET 8** Web API implements a **simple ledger** service with **thread-safe** in-memory storage for:
1. **Recording user's transactions** (positive → deposit, negative → withdrawal)
2. **Retrieving the current balance**
3. **Viewing all transactions**

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet)

## Running the API

1. **Clone** this repository
2. **Build** the project (Visual Studio will work too):
   ```bash
   dotnet build
   dotnet run
   ```
3. The API will start on the default address (for example, http://localhost:5000).

## Usage
Use curl or any REST client like Postman to call the API endpoints. All parameters are provided via request headers.
```
POST /api/ledger/transaction
Headers:
- userId: string
- amount: decimal (positive for deposit, negative for withdrawal)

GET /api/ledger/balance
Headers:
- userId: string

GET /api/ledger/transactions
Headers:
- userId: string
```