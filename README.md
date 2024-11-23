# **Back-End Project - [InventorySystem]**

### Description
This is the back-end of an inventory management system developed using a multi-layered architecture. It is designed to efficiently handle perishable goods, enabling the management of products, inventory by location, orders, customers, suppliers, and employees. The system emphasizes best programming practices and robust error handling across different layers to ensure better data protection. Additionally, stored procedures are utilized to execute the required queries and relay results to the upper layers. The system also includes capabilities for generating reports on products, inventory, and employee management to streamline tasks like order taking and processing.

---

## **Tabla de Contenidos**

1. [Technologies Used](#Technologies-Used)
2. [Architecture](#Architecture)
3. [Installation and Configuration](#Installation-and-Configuration)
4. [Main Features](#Main-Features)

---

## **Technologies Used**

A list of the technologies and tools utilized:

- **Language:** C#
- **Framework:** .NET Framework 4.8
- **Database:** SQL Server
- **Front-End:** React
- **ORM / Data Access:** ADO.NET and stored procedures
- **Configuration Tools:** `System.Configuration` for database connection
- **Others:** Crystal Reports for report generation.

---

## **Architecture**
### Layered Design

- **Presentation Layer:** Contains the user interface and consumes the API endpoints. The front-end is developed in React and receives data from this layer. You can find the front-end repository [here](https://github.com/your-username/front-repo-name).
- **API Controllers:** API endpoints for accessing methods that retrieve information.
- **Business Layer:** Handles data validation and error management before passing data to other layers. This layer ensures that if a user inputs incorrect data, a personalized error message is displayed.
- **Attributes Layer:** Initializes the attributes of the objects. The objects used in the back-end are: Client, Order Detail, Employee, Inventory, Order, Response Message, Product, Supplier, Branch, Employee Type, and Product Type.
- **DataAccess Layer:** Responsible for connecting to the SQL Server Management Studio database.
- **Data Model:** Database schema and stored procedures managed in SQL Server Management Studio.

### Database Diagram

![Diagram](https://github.com/user-attachments/assets/9544baad-5ab6-4156-861c-7d6ca717d4ce)

---

## **Installation and Configuration**

Steps to install and set up the project locally.

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/repository-name-backend.git
   cd repository-name-backend
   ```
2. **Database Configuration:**

   - Ensure SQL Server is installed and that stored procedures and tables are created in your database.
   - Configure the connection string in the web.config file (.NET Framework) to match your local server and database.
     ```xml
     <connectionStrings>
         <add name="DefaultConnection" 
              connectionString="Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;User ID=USERNAME;Password=PASSWORD"
              providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```
## **Main Features**

Key functionalities of the back-end:

- Management of products, branches, clients, suppliers, employees, and orders.
- Order generation for clients with the ability to create detailed reports for each order.
- Real-time inventory management with reporting capabilities.
- Reports generated using Crystal Reports.


