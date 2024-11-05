# Ocelot API Gateway with Multiple Microservices and JWT Authentication

This project demonstrates an API Gateway setup using Ocelot in .NET 6.0. The gateway routes requests to multiple downstream microservices, providing load balancing and JWT authentication for securing API routes.

## Features
- **Ocelot API Gateway**: Acts as a gateway to multiple microservices.
- **Microservices**: 
  - Products Service (on ports `5001` and `5002`)
  - Orders Service (on ports `5003` and `5004`)
- **JWT Authentication**: Secure routes using JSON Web Tokens (JWT).
- **Load Balancing**: Requests are load balanced between service instances using the Round-Robin algorithm.
  
## Project Structure
- **OcelotGateway**: The API Gateway project using Ocelot.
- **ProductsService1 & ProductsService2**: Two instances of the Products service running on different ports.
- **OrdersService1 & OrdersService2**: Two instances of the Orders service running on different ports.

## Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Postman](https://www.postman.com/) or [cURL](https://curl.se/) for testing API requests
- A tool or service for generating JWT tokens (e.g., a custom Token API in the project or online services)

## Setup

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/your-repo.git
cd your-repo
