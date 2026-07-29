# HealthApp API

A simple ASP.NET Core Minimal API built using .NET that demonstrates basic REST API functionality.

## Features

- GET `/health` - Returns application health status and developer name.
- GET `/api/items` - Returns a list of sample in-memory items.
- POST `/api/items` - Adds a new item to the in-memory collection.
- Basic request validation.
- Swagger/OpenAPI support.

---

## Project Structure

```text
Health_App
│
├── Dtos
│   └── CreateItemDto.cs
│
├── Models
│   └── Item.cs
│
├── Results
│   ├── HealthEndpoint.png
│   ├── GetItems.png
│   └── PostItem.png
│
├── Program.cs
├── README.md
└── HealthApp.csproj
```

---

## Prerequisites

- .NET SDK 8.0 or later
- Visual Studio Code or Visual Studio

---

## Running the Application

Clone the repository:

```bash
git clone <repository-url>
```

Navigate to the project directory:

```bash
cd Health_App
```

Run the application:

```bash
dotnet run
```

The API will start and display the application URLs in the terminal.

---

## API Endpoints

### Health Check

**Request**

```http
GET /health
```

**Sample Response**

```json
{
  "status": "Healthy",
  "name": "Kirtan Khare"
}
```

---

### Get Items

**Request**

```http
GET /api/items
```

**Sample Response**

```json
[
  {
    "id": 1,
    "name": "Book"
  },
  {
    "id": 2,
    "name": "Laptop"
  },
  {
    "id": 3,
    "name": "Mouse"
  }
]
```

---

### Add Item

**Request**

```http
POST /api/items
```

**Sample Request Body**

```json
{
  "name": "Keyboard"
}
```

**Sample Response**

```json
{
  "id": 4,
  "name": "Keyboard"
}
```

---

## Validation

The following validation is implemented:

- Item name is required.
- Item name cannot be empty or whitespace.

Example invalid request:

```json
{
  "name": ""
}
```

Response:

```http
400 Bad Request
```

---

## Example cURL Commands

### Health Endpoint

```bash
curl -X GET https://localhost:<port>/health
```

### Get Items

```bash
curl -X GET https://localhost:<port>/api/items
```

### Add Item

```bash
curl -X POST https://localhost:<port>/api/items \
-H "Content-Type: application/json" \
-d "{\"name\":\"Keyboard\"}"
```

---

## Testing

The API was tested using Postman.

Screenshots of test results are available in the `Results` folder.

---

## Author

**Kirtan Khare**
