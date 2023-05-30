using BackV2.BackV2Exception;
using System.Diagnostics;

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
                await context.Response.WriteAsync(ex.Message);

            }
        }
    }
}
