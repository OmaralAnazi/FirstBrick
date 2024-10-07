# FirstBrick Backend API
FirstBrick is a microservices-based platform that democratizes real estate investing, allowing users to invest in real estate projects with ease. This platform uses modern technologies like .NET Core, RabbitMQ for asynchronous messaging, and PostgreSQL for database management.


## Overview
This project consists of three main microservices:

1. **User Service:** Handles user registration, authentication, and profile management.
2. **Fund Service:** Manages real estate projects, user investments, and portfolio details.
3. **Payment Service:** Handles all financial transactions, including deposits, withdrawals, and balance management.

The communication between these services is handled via event-driven architecture using RabbitMQ and EasyNetQ.


## Microservices & Endpoints
**User Service**:
1. `POST /api/auth/register` - Register a new user.
2. `POST /api/auth/login` - Authenticate and log in a user.
3. `GET /api/users/me` - Retrieve the profile of the currently logged-in user.
4. `GET /api/users/{userId}` - Retrieve the profile of a specific user (**Admin-only**).
5. `PUT /api/users/{userId}` - Update a specific user's profile (**Admin-only**).
6. `PUT /api/users` - Update the profile of the logged-in user.

**Fund Service**:
1. `GET /api/funds` - Retrieve a list of available funds for investment.
2. `POST /api/funds` - Create a new fund (**Admin-only**).
3. `POST /api/funds/invest` - Make an investment into a fund.
4. `GET /api/protfolio` - Retrieve the investment portfolio of the logged-in user.
5. `GET /api/protfolio/{fundId}` - Retrieve details about a specific fund in the user's portfolio.

**Payment Service**:
1. `POST /api/payment/withdraw` - Withdraw funds from the user's account.
2. `POST /api/payment/deposit` - Deposit funds into the user's account.
3. `GET /api/payment/balance` - Retrieve the current balance of the user's account.
4. `GET /api/payment/transactions` - Retrieve a paginated list of financial transactions.


## Event-Driven Architecture (Message Broker)
The project uses RabbitMQ and EasyNetQ to implement an event-driven architecture between the microservices. Here are the events used:

1. **UserRegisteredEvent**:
    - **Publisher:** User Service
    - **Subscriber:** Payment Service
    - **Description:** When a user registers, the Payment Service creates a new wallet for the user.

2. **InvestmentRequestedEvent**:
    - **Publisher:** Fund Service
    - **Subscriber:** Payment Service
    - **Description:** When a user requests to invest in a fund, the Payment Service either approves or rejects the investment transaction.

3. **InvestmentProcessedEvent**:
    - **Publisher:** Payment Service
    - **Subscriber:** Fund Service
    - **Description:** After the Payment Service processes the investment, the Fund Service updates the investment status as approved or rejected.


## Setup Guide
**Prerequisites:**
- .NET Core SDK
- RabbitMQ
- PostgreSQL

**Steps to Run the Project:**
1. Clone the repository:
```
git clone https://github.com/OmaralAnazi/FirstBrick.git
cd firstbrick
```

2. Install dependencies: 
```
dotnet restore
```

3. Set up the PostgreSQL Database: Update the connection string in the appsettings.json file with your PostgreSQL credentials.
```
"ConnectionStrings": {
   "DefaultConnection": "Host=localhost;Database=FirstBrickDB;Username=your_username;Password=your_password"
}
```

4. Configure RabbitMQ: Update the RabbitMQ connection settings in the appsettings.json file with your RabbitMQ credentials (ensure that the RabbitMQ server is running before starting the project).
```
"MessageBroker": {
   "Host": "localhost",
   "Username": "guest",
   "Password": "guest"
}
```

5. Run the Project:
```
dotnet run
```
