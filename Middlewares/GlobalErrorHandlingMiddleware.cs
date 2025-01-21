using EmployeeDirectory.Helpers;
using System.Net;
using System.Text.Json;

namespace EmployeeDirectory.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate requestDelegate, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _requestDelegate = requestDelegate ?? throw new ArgumentNullException(nameof(requestDelegate));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception appError)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch(appError)
                {
                    case RepositoryException re:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException kf:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        _logger.LogError(appError, appError.Message);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { errorMessage = appError?.Message });
                await response.WriteAsync(result);
            }
        }

        

        
    }
}
