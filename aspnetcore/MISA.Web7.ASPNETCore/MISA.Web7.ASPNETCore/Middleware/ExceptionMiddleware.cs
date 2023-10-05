using MISA.Web7.ASPNETCore.Domain;

namespace MISA.Web7.ASPNETCore
{
    public class ExceptionMiddleware
    {
        #region Property
        private readonly RequestDelegate _next;
        #endregion
        #region Constructor
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Methods
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Console.WriteLine(exception);
            context.Response.ContentType = "application/json";

            if (exception is NotFoundException notFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode = notFoundException.ErrorCode,
                    UserMsg = Domain.Resources.ResourceVN.NotFoundError,
                    DevMsg = exception.Message,
                    TraceId = context.TraceIdentifier,
                    MoreInfo = exception.HelpLink
                }.ToString() ?? "");
            }
            else if (exception is ConflictException conflict)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode = conflict.ErrorCode,
                    UserMsg = Domain.Resources.ResourceVN.ConflictError,
                    DevMsg = exception.Message,
                    TraceId = context.TraceIdentifier,
                    MoreInfo = exception.HelpLink
                }.ToString());
            }
            else if(exception is ValidateException validateException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode= validateException.ErrorCode,
                    UserMsg = Domain.Resources.ResourceVN.ValidationError,
                    DevMsg = exception.Message,
                    TraceId = context.TraceIdentifier,
                    MoreInfo = exception.HelpLink
                }.ToString());
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(text: new BaseException()
                {
                    ErrorCode = context.Response.StatusCode,
                    UserMsg = Domain.Resources.ResourceVN.SystemError,
#if DEBUG
                    DevMsg = exception.Message,
#else
                    DevMsg = "",
#endif
                    TraceId = context.TraceIdentifier,
                    MoreInfo = exception.HelpLink
                }.ToString());
            }
        }
        #endregion
    }
}
