# Todo Backend (ASP.NET Core Minimal API)

## Overview
This project is a lightweight .NET backend for the Lab 5 React front-end. It exposes a single API endpoint that returns an in-memory list of todo items.

The backend is intentionally simple (no database) to match the “deploy frontend + backend to Azure” learning goal.

## Tech Stack
- ASP.NET Core Web API (Minimal API style)
- CORS enabled for the React development server

## Local Development

### Start the API
From inside `todo-backend/`:

```bash
dotnet run
```

By default (from `Properties/launchSettings.json`), the app listens at:
- `http://localhost:5000`
- `https://localhost:5001`

### Verify the endpoint
Open in your browser or use curl:

`GET http://localhost:5000/api/todos`

You should receive JSON like:
```json
[
  { "id": 1, "title": "Read the lab sheet", "isCompleted": true },
  { "id": 2, "title": "Run the backend API", "isCompleted": false }
]
```

## API Contract

### `GET /api/todos`
Returns an array of todo items.

Each item has:
- `id` (number)
- `title` (string)
- `isCompleted` (boolean)

## CORS Configuration
The backend enables CORS using policy name `FrontendPolicy`.

Allowed origins:
- `http://localhost:3000`
- `https://localhost:3000`

It allows:
- any header
- any method

## Important Note About State
The todo list is stored in-memory in `Program.cs` as a fixed array. That means:
- The endpoint always returns the original demo values.
- There is no persistence across server restarts.
- The frontend’s “toggle done/pending” behavior only updates the UI state (it does not write back to the API).

## Azure Deployment (Lab 5 style)
When you deploy this to Azure App Service:
1. Create an **Azure App Service** for a `.NET` runtime.
2. Connect the deployment center to your GitHub repo (Azure will generate a workflow).
3. After deployment, confirm the API is reachable at:
   - `https://<your-api-app-name>.azurewebsites.net/api/todos`

Then update the frontend’s `VITE_API_URL` to point to your deployed backend URL.

