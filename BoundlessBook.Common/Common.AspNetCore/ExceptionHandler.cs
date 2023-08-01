using BoundlessBook.Common.Common.Application.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BoundlessBook.Common.Common.AspNetCore;

public static class ApiCustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseApiCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiCustomExceptionHandlerMiddleware>();
    }
}

public class ApiCustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostingEnvironment _env;
    private readonly ILogger<ApiCustomExceptionHandlerMiddleware> _logger;

    public ApiCustomExceptionHandlerMiddleware(RequestDelegate next,
        IHostingEnvironment env,
        ILogger<ApiCustomExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _env = env;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        string message = null;
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;


        try
        {
            await _next(context);
        }
        catch (InvalidDomainException exception)
        {
            _logger.LogError(exception, exception.Message);
            SetErrorMessage(exception);
            await WriteToResponseAsync();
        }
        catch (InvalidCommandException exception)
        {
            _logger.LogError(exception, exception.Message);
            httpStatusCode = HttpStatusCode.BadRequest;
            SetErrorMessage(exception);
            await WriteToResponseAsync();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            SetErrorMessage(exception);
            await WriteToResponseAsync();
        }

        void SetErrorMessage(Exception exception)
        {
            message = exception.Message;
            if (_env.IsDevelopment())
            {
                var dic = new Dictionary<string, string>
                {
                    ["Exception"] = exception.Message,
                    ["StackTrace"] = exception.StackTrace,
                };
                if (exception.InnerException != null)
                {
                    dic.Add("InnerException.Exception", exception.InnerException.Message);
                    dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
                }

                message = JsonConvert.SerializeObject(dic);
            }
        }
        async Task WriteToResponseAsync()
        {
            if (context.Response.HasStarted)
                throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");

            var result = new OperationResult()
            {
                Title = "خطا",
                Message = message,
                Status = OperationResultStatus.Error
            };
            var json = JsonConvert.SerializeObject(result);

            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}