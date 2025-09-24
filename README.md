# Chatbot API (.NET 8)

This is a **.NET 8 API** project designed to securely serve data to a chatbot service (e.g., Unifonic). It supports:

- **API Key authentication** for secure server-to-server communication.
- **Localization** using the `Accept-Language` header.
- Swagger UI for testing endpoints.
- Route-based and query-based endpoints.

---

## Table of Contents

- [Features](#features)
- [Requirements](#requirements)
- [Setup](#setup)
- [Configuration](#configuration)
- [Running the API](#running-the-api)
- [Endpoints](#endpoints)
- [Authentication](#authentication)
- [Localization](#localization)
- [Swagger UI](#swagger-ui)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Secure API access** using a custom API key.
- **Swagger integration** with API key and `Accept-Language` headers.
- **Localization support** for multiple languages (`en-US`, `ar-SA`).
- **Route parameters** for data access, e.g., validating ID/Iqama numbers or OTP.

---

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Git
- Visual Studio 2022 / VS Code (recommended)
- A GitHub account for repo hosting

---

## Setup

1. Clone the repository:

```bash
git clone <repo-url>
cd <project-folder>
