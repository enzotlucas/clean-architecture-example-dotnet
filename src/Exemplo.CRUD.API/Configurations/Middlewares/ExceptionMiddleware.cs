namespace Exemplo.CRUD.API.Configurations.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger; 

        public ExceptionMiddleware(RequestDelegate next,
                                   ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (ProductNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);

                await HandleExceptionAsync(context, ex);
            }
            catch (BusinessException ex)
            {
                _logger.LogWarning(ex.Message);

                await HandleExceptionAsync(context, ex);
            }
            catch (InfrastructureException ex)
            {
                _logger.LogError(ex.Message);

                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, ProductNotFoundException ex)
        {
            var code = HttpStatusCode.NotFound;

            return HandleExceptionAsync(context, ex, code);
        }

        private static Task HandleExceptionAsync(HttpContext context, BusinessException ex)
        {
            var code = HttpStatusCode.BadRequest;

            return HandleExceptionAsync(context, ex, code);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            return HandleExceptionAsync(context, ex, code);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode code)
        {
            var result = JsonConvert.SerializeObject(new { error = ex.Message });

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}