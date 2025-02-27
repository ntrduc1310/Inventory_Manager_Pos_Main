# Store Management System Using Multi-Layer Architecture

## Introduction
The store management system is developed to optimize the management process of goods, transactions, personnel, and revenue reporting for retail stores. The system applies a multi-layer architecture to ensure modularity, maintainability, and scalability.

## Technologies Used
- **Programming Language**: C# (.NET Framework)
- **Database**: SQL Server 2019
- **ORM**: Entity Framework Core
- **UI Framework**: Windows Forms + Guna.UI2 Framework
- **Version Control**: GitHub
- **Development Tools**: Visual Studio 2022

## System Architecture
The system is built using a **4-layer architecture**:
1. **Presentation Layer (PL)**: User interface with Windows Forms
2. **Business Logic Layer (BL)**: Business logic processing
3. **Data Access Layer (DL)**: Database interactions
4. **Data Transfer Objects (DTO)**: Defines data exchange structures

## Key Features
### 1. Product Management
- Add, edit, delete products
- Manage product categories
- Track inventory levels

### 2. Sales Management
- Generate sales invoices
- QR code scanning for payments
- Print invoices

### 3. Purchase Management
- Manage supplier purchases
- Track purchase history

### 4. Employee and Role Management
- Add, edit, delete employee accounts
- Assign roles and permissions

### 5. Reporting & Data Analysis
- Revenue and profit statistics
- Reports on sold products

## Database Design
- **ERD Diagram**: Describes main tables and relationships
- **Table Structure**:
  - `Products`: Manage products
  - `Category`: Product categories
  - `Customer`: Customer information
  - `Users`: System user management
  - `Sale`: Sales history
  - `Purchase`: Purchase management

## Installation & Running Instructions
### 1. System Requirements
- Visual Studio 2022
- SQL Server 2019
- .NET Framework 4.7 or later

### 2. Installation Guide
1. Clone the repository:
   ```sh
   git clone https://github.com/petertrong/Inventory_Manager_Pos_Main
   ```
2. Open the project in Visual Studio 2022
3. Configure SQL Server connection string in `appsettings.json`
4. Initialize the database:
   ```sh
   update-database
   ```
5. Build and run the application

## Challenges & Solutions
- **Concurrent Access**: Applied Transaction with appropriate Isolation Level
- **Query Performance**: Optimized indexing, used Lazy Loading

## Future Development
- **Integrate online payment**
- **Develop a mobile app version**
- **Enhance reporting with AI**

## References
1. Microsoft Documentation - Entity Framework Core
2. Clean Architecture: A Craftsman's Guide to Software Structure and Design
3. Design Patterns: Elements of Reusable Object-Oriented Software
4. SQL Server 2019 Administration Inside Out
