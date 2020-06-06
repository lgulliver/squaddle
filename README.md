# Squaddle

A swiss army knife of tools for squads for planning, retros and squad health

# Status

## Builds

| Component | Status of CI Build (`master`) |
| ---- | ---- |
| Squaddle.Web | ![Squaddle.Web-CI](https://github.com/lgulliver/squaddle/workflows/Squaddle.Web-CI/badge.svg?branch=master) |
| Squaddle.Functions.Chat | ![Squaddle.Functions.Chat-CI](https://github.com/lgulliver/squaddle/workflows/Squaddle.Functions.Chat-CI/badge.svg?branch=master) |
| Squaddle.Functions.Proxy | ![Squaddle.Functions.Proxy-CI](https://github.com/lgulliver/squaddle/workflows/Squaddle.Functions.Proxy-CI/badge.svg?branch=master) |
| Squaddle.Functions.Session | ![Squaddle.Functions.Session-CI](https://github.com/lgulliver/squaddle/workflows/Squaddle.Functions.Session-CI/badge.svg?branch=master) |


# Goals

- To be completely serverless
- Learn Blazor WebAssembly
- Provide some neat tools for teams

# Disclaimer

I'm not bothering with writing unit tests for this project. Feel free to add them if you like, but I'm not too bothered by it at this stage.

# Contributing

We have `local.settings.json` as an entry in `.gitignore` so that we don't accidentally push any secrets used locally when doing dev back to the repo. With this in mind, you'll need to create a few to get going.

## Pre-requisites

You will need a minimum of the following to contribute to this project:

- DotNetCore 3.1.300
- An Azure Subscription
- An Azure SignalR Service in Serverless Mode
- Your IDE of choice with the [appropriate extensions for Azure Function Apps ](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-local)

## Squaddle.Functions.Proxy

`local.settings.json`
```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",    
    "AZURE_FUNCTION_PROXY_BACKEND_URL_DECODE_SLASHES": true,
    "chat_api": "http://127.0.0.1:7072",
    "session_api": "http://127.0.0.1:7073"
  },
  "Host": {
    "LocalHttpPort": 7071,
    "CORS": "*",
    "CORSCredentials": false
  }
}
```

## Squaddle.Functions.Chat

`local.settings.json`
```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AzureSignalRConnectionString": "<YOUR SIGNALR CONNECTION STRING>"
  },
  "Host": {
    "LocalHttpPort": 7072,
    "CORS": "*",
    "CORSCredentials": false
  }
}
```
