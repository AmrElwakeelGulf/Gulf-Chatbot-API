namespace Gulf_Chatbot_API.Middleware
{
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Read request info
            var method = context.Request.Method;
            var path = context.Request.Path;
            var queryString = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : "";
            var headers = context.Request.Headers;

            // Read body if necessary
            string body = "";
            if (context.Request.ContentLength > 0 &&
                context.Request.ContentType != null &&
                context.Request.ContentType.Contains("application/json"))
            {
                context.Request.EnableBuffering();
                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
                {
                    body = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;
                }
            }

            // Build log message
            var logMessage = new StringBuilder();
            logMessage.AppendLine($"-----------------------------{DateTime.UtcNow.AddHours(3)}----------------------------------");
            logMessage.AppendLine("Incoming Request:");
            logMessage.AppendLine($"Method: {method}");
            logMessage.AppendLine($"Path: {path}");
            logMessage.AppendLine($"Query: {queryString}");
            logMessage.AppendLine("Headers:");
            foreach (var header in headers)
            {
                logMessage.AppendLine($"{header.Key}: {header.Value}");
            }
            if (!string.IsNullOrEmpty(body))
                logMessage.AppendLine($"Body: {body}");

            logMessage.AppendLine("---------------------------------------------------------------------------------------------");
            // Log to file (using ILogger)
            _logger.LogInformation(logMessage.ToString());

            // Call the next middleware
            await _next(context);
        }
    }

}
