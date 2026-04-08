# 🏦 DBS Credit Union Management System

A desktop banking application built using **C# Windows Forms (.NET Framework)** with a **Microsoft SQL Server** backend.  
This project was developed as part of an Object-Oriented Programming assignment to simulate a **Credit Union system** used by internal staff to perform core banking operations.

> 

---

## 📌 Features

### 🔐 Authentication
- Secure login system for internal staff
- Password masking using `*`
- Error handling for invalid credentials

### 📊 Account Management
- View all bank accounts in a data grid
- Create new accounts
- Edit existing account details (with restricted fields)

### 💰 Transactions
- Deposit funds
- Withdraw funds
- Transfer funds (internal & external)
- Real-time balance updates

### 🔄 Transfer System
- Internal transfers between accounts
- External transfers (for current accounts only)
- Validation for:
  - Available balance + overdraft
  - Positive transfer amount

### 🧾 Transaction History
- Full audit trail of:
  - Deposits
  - Withdrawals
  - Transfers

### 🧩 Additional Features
- XML serialization of account data
- Configuration file for default sort code
- Three-tier architecture implementation

---

## 🏗️ Architecture

This application follows a **3-tier architecture**:

1. **Presentation Layer (UI)**
   - Windows Forms interface
   - User interaction and input validation

2. **Business Logic Layer**
   - Core logic for:
     - Account handling
     - Transactions
     - Validation rules

3. **Data Access Layer**
   - SQL Server database operations
   - CRUD functionality

---

## 🗄️ Database (SQL Server)

The system uses **Microsoft SQL Server** to manage:

- Users (Login credentials)
- Accounts
- Transactions

### Example Tables:
- `Users`
- `Accounts`
- `Transactions`

---

## ⚙️ Technologies Used

- C# (.NET Framework)
- Windows Forms (WinForms)
- Microsoft SQL Server
- ADO.NET
- XML Serialization

---

## 🖥️ Application Workflow

1. User launches the application  
2. Login screen is displayed  
3. After successful login:
   - Menu options update dynamically  
   - Account grid is displayed  
4. User can:
   - Create/Edit accounts  
   - Perform transactions  
   - View transaction history  


