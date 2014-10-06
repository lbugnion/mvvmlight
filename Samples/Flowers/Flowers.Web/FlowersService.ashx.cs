using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Flowers.Data.Model;
using Flowers.Helpers;
using Flowers.Model;
using Newtonsoft.Json;

namespace Flowers
{
    public class FlowersService : IHttpHandler
    {
        private const string JsonFilePath = "App_Data/flowers.json";
        private const string BakJsonFilePath = "App_Data/flowers.bak.json";

        public void ProcessRequest(HttpContext context)
        {
            Log.LogEntry("Received request", context);

            var id = context.Request.QueryString[WebConstants.AuthenticationKey];

            if (string.IsNullOrEmpty(id)
                || id != WebConstants.AuthenticationId)
            {
                Log.LogEntry("Invalid or missing key");

                context.Response.ContentType = "text/plain";
                context.Response.Write("Invalid or missing key");
                return;
            }

            Log.LogEntry("ID: " + id);

            var action = context.Request.QueryString[WebConstants.ActionKey];

            if (string.IsNullOrEmpty(action))
            {
                Log.LogEntry("Missing action");

                context.Response.ContentType = "text/plain";
                context.Response.Write("Missing action");
                return;
            }

            Log.LogEntry("Action: " + action);

            switch (action)
            {
                case WebConstants.ActionGet:
                {
                    try
                    {
                        var jsonPath = context.Request.MapPath(JsonFilePath);
                        var json = Get(jsonPath);

                        context.Response.ContentType = "application/json";
                        context.Response.Write(json);
                        Log.LogEntry("Get was executed");
                        return;
                    }
                    catch (Exception ex)
                    {
                        Log.LogEntry("Error in Get: " + ex.Message);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(ex.Message);
                        return;
                    }
                }
                break;

                case WebConstants.ActionSave:
                {
                    try
                    {
                        var jsonPath = context.Request.MapPath(JsonFilePath);
                        var json = context.Request.Form["flower"];
                        var flower = Save(jsonPath, json);

                        context.Response.ContentType = "text/plain";
                        context.Response.Write(flower.Id);
                        Log.LogEntry("Save was executed");
                    }
                    catch (Exception ex)
                    {
                        Log.LogEntry("Error in Save: " + ex.Message);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(ex.Message);
                        return;
                    }
                }
                break;

                case WebConstants.ActionReset:
                {
                    var bakJsonPath = context.Request.MapPath(BakJsonFilePath);
                    var jsonPath = context.Request.MapPath(JsonFilePath);
                    Reset(bakJsonPath, jsonPath);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Done");
                    Log.LogEntry("Reset was executed");
                    return;
                }
                break;

                case WebConstants.ActionClearLog:
                    var logCleared = Log.ClearLog();
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(logCleared ? "Done" : "Not done");
                    break;

                default:
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Invalid action");
                    Log.LogEntry("Invalid action");
                    break;
            }
        }

        private void Reset(string bakJsonPath, string jsonPath)
        {
            using (var reader = new StreamReader(bakJsonPath))
            {
                using (var stream = File.Open(jsonPath, FileMode.Create))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write(reader.ReadToEnd());
                    }
                }
            }
        }

        private Flower Save(string path, string newJson)
        {
            IList<Flower> list;

            using (var reader = new StreamReader(path))
            {
                var json = reader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<FlowersResult>(json);
                list = result.Data;
            }

            if (list == null
                || list.Count == 0)
            {
                Log.LogEntry("List is null or empty");
                throw new ArgumentException("Invalid JSON file on server");
            }

            var newFlower = JsonConvert.DeserializeObject<Flower>(newJson);
            Log.LogEntry("Flower existing ID: " + newFlower.Id);

            if (string.IsNullOrEmpty(newFlower.Id))
            {
                newFlower.Id = Guid.NewGuid().ToString();
                Log.LogEntry("Flower new ID: " + newFlower.Id);
            }

            var existingFlower = list.FirstOrDefault(f => f.Id == newFlower.Id);

            if (existingFlower == null)
            {
                Log.LogEntry("No existing flower found");
                list.Add(newFlower);
            }
            else
            {
                existingFlower.Description = newFlower.Description;
                existingFlower.Image = newFlower.Image;
                existingFlower.Name = newFlower.Name;
                existingFlower.Comments = newFlower.Comments;
                Log.LogEntry("Copied new flower to existing flower");
            }

            var newResult = new FlowersResult
            {
                Data = list
            };

            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var writer = new StreamWriter(stream))
                {
                    var listJson = JsonConvert.SerializeObject(newResult);
                    writer.Write(listJson);
                }
            }

            Log.LogEntry("Saved to file");

            return newFlower;
        }

        private string Get(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}