using System;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MyHttpClient
{
    public record class Todo(
    int? UserId = null,
    int? Id = null,
    string? Title = null,
    bool? Completed = null);

    public class MyHttpMethod
    {       
        public static async Task GetAsync(HttpClient httpClient)
        {

            using HttpResponseMessage response = await httpClient.GetAsync("todos/5");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{jsonResponse}\n");

        }
        public static async Task GetFromJsonAsync(HttpClient httpClient)
        {
            var todos = await httpClient.GetFromJsonAsync<List<Todo>>("todos?userId=3&completed=false");

            Console.WriteLine("GET https://jsonplaceholder.typicode.com/todos?userId=1&completed=false HTTP/1.1");
            todos?.ForEach (Console.WriteLine);
            Console.WriteLine();

        }
        public static async Task PostAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new (
                JsonSerializer.Serialize(new 
                {
                    userId = 10,
                    id = 1,
                    title = "write code sample",
                    completed = true,
                }),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PostAsync("todos", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");

        }
        public static async Task PostAsJsonAsync(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.PostAsJsonAsync("todos", new Todo(UserId: 9, Id: 99, Title: "Show extensions", Completed: false));
            
            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var todo = await response.Content.ReadFromJsonAsync<Todo>();
            Console.WriteLine($"{todo}\n");
        }

        public static async Task PutAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    userId = 1,
                    id = 1,
                    title = "for bar",
                    completed = true

                }),
                Encoding.UTF8,
                "application/json");
            using HttpResponseMessage response = await httpClient.PutAsync("todos/3", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonresponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonresponse}\n");               
        }
        public static async Task PutAsJsonAsync(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.PutAsJsonAsync("todos/5", new Todo { Title = "partially update todo", Completed = true});

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonresponse = await response.Content.ReadFromJsonAsync<Todo>();

            Console.WriteLine($"{jsonresponse}\n");
        }
        
        public static async Task PatchAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize (new
                {
                    completed = true,
                }),
                Encoding.UTF8,
                "application/json");
            using HttpResponseMessage response = await httpClient.PatchAsync("todos/1", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonresponse = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine($"{jsonresponse}\n");
        }
        public static async Task DeleteAsync(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.DeleteAsync("todos/1");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonresponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{jsonresponse}\n");
        }

        public static async Task HeadAsync(HttpClient httpClient)
        {
            using HttpRequestMessage request = new(HttpMethod.Head, "https://www.example.com");

            using HttpResponseMessage response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            foreach(var head in response.Headers)
            {
                Console.WriteLine($"{head.Key}: {string.Join(", ", head.Value)}");
            }
            Console.WriteLine();
        }

        public static async Task OptionAsync(HttpClient httpClient)
        {
            using HttpRequestMessage request = new(HttpMethod.Options, "https://jsonplaceholder.typicode.com/todos");

            using HttpResponseMessage response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            foreach(var option in response.Headers)
            {
                Console.WriteLine($"{option.Key}: {string.Join(", ", option.Value)}");
            }
            Console.WriteLine(); 
        }
        
        public static async Task GetByteArrayAsync(HttpClient httpClient)
        {
            byte[] data = await httpClient.GetByteArrayAsync("todos/3");

            Console.WriteLine($"Length: {data.Length} bytes\n");

            Console.WriteLine($"UTF-8: {Encoding.UTF8.GetString(data)}\n");   
        }

        public static async Task GetStreamAsync(HttpClient httpClient)
        {
            using Stream stream = await httpClient.GetStreamAsync("todos/1");

            using StreamReader reader = new(stream);

            string content = await reader.ReadToEndAsync();

            Console.WriteLine($"Stream: {content}\n");
        }

        public static async Task GetStringAsync(HttpClient httpClient)
        {
            string content = await httpClient.GetStringAsync("todos/1");

            Console.WriteLine($"String: {content} \n");
        }
}
    static class HttpResponseMessageExtensions
    {
        internal static void WriteRequestToConsole(this HttpResponseMessage response)
        {
            if (response is null)
            {
                return;
            }

            var request = response.RequestMessage;
            Console.Write($"{request?.Method} ");
            Console.Write($"{request?.RequestUri} ");
            Console.WriteLine($"HTTP/{request?.Version}");
        }
    }
    public class Program
    {
        private static HttpClient sharedClient = new HttpClient()
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
        };
        public static async Task Main(string[] args)
        {
            await MyHttpMethod.GetAsync(sharedClient);

            await MyHttpMethod.GetFromJsonAsync(sharedClient);

            await MyHttpMethod.PostAsync(sharedClient);

            await MyHttpMethod.PostAsJsonAsync(sharedClient);

            await MyHttpMethod.PutAsync(sharedClient);

            await MyHttpMethod.PutAsJsonAsync(sharedClient);
            
            await MyHttpMethod.DeleteAsync(sharedClient);

            await MyHttpMethod.PatchAsync(sharedClient);

            await MyHttpMethod.HeadAsync(sharedClient);

            await MyHttpMethod.OptionAsync(sharedClient);

            await MyHttpMethod.GetByteArrayAsync(sharedClient);

            await MyHttpMethod.GetStreamAsync(sharedClient);

            await MyHttpMethod.GetStringAsync(sharedClient);

        }
    }
}
