# Ledger API

This **.NET 8** Web API implements a **simple ledger** service with **thread-safe** in-memory storage for:
1. **Recording user's transactions** (positive → deposit, negative → withdrawal)
2. **Retrieving the current balance**
3. **Viewing all transactions**

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet)

## Usage
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