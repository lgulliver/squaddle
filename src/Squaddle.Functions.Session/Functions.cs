using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Squaddle.Shared.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Linq;

namespace Squaddle.Functions.Chat
{
    public static class Functions
    {
        [FunctionName("CreateRoom")]
        public static IActionResult RunCreateRoom(
            [HttpTrigger(AuthorizationLevel.Function, "POST")] Room roomDocument,
            [CosmosDB(databaseName: "squaddle",
            collectionName: "active_rooms",
            ConnectionStringSetting = "CosmosDBConnectionString")] out Room roomDocumentToSave,
            ILogger log)
        {
            log.LogInformation("Request to create a room started.");

            if(roomDocument == null)
            {
                log.LogError("No valid room data sent in request.");
                roomDocumentToSave = null;
                return new BadRequestResult();
            }

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);

            log.LogInformation($"Room code {finalString} generated.");

            roomDocument.RoomCode = finalString;
            roomDocumentToSave = roomDocument;

            return new OkObjectResult(roomDocumentToSave);
        }

        [FunctionName("VerifyRoom")]
        public static IActionResult VerifyRoom(
            [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "VerifyRoom/{id}")] HttpRequest request,
            string id,
            [CosmosDB(databaseName: "squaddle",
            collectionName: "active_rooms",
            ConnectionStringSetting = "CosmosDBConnectionString")] DocumentClient client,
            ILogger log)
        {
            log.LogInformation("Request to verify a room started.");

            string roomCode = id;
            if (string.IsNullOrWhiteSpace(roomCode))
            {
                return new NotFoundResult();
            }

            Uri collectionUri = UriFactory.CreateDocumentCollectionUri("squaddle", "active_rooms");

            log.LogInformation($"Searching for room: {roomCode}");

            Room roomQuery = client.CreateDocumentQuery<Room>(collectionUri)
                .Where(param => param.RoomCode == roomCode).Take(1).AsEnumerable().FirstOrDefault();

            if (roomQuery == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(roomQuery);
        }
    }

}
