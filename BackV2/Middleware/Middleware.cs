using BackV2.BackV2Exception;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BackV2.Middleware
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                Debug.WriteLine("After next");
                //await context.Response.WriteAsync("After next");
                await _next(context);
                Debug.WriteLine("Before next");
                //await context.Response.WriteAsync("Before next");
            }
            catch (BaseException ex)
            {
                Debug.WriteLine($"Error (MiddleWare class): {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                var output = new JsonObject
                {
                    ["status"] = "error",
                    ["message"] = ex.Message    
                };
                var options = new JsonSerializerOptions { WriteIndented = true };
                Console.WriteLine(output.ToJsonString(options));
                await context.Response.WriteAsJsonAsync(output);

            }
        }
    }
}
