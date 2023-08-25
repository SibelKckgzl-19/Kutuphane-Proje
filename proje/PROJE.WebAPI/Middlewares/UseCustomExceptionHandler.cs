using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Diagnostics;
using PROJE.Business.CustomExceptions;
using System.Text.Json;

namespace PROJE.WebAPI.Middlewares
{
    public static  class UseCustomExceptionHandler
    {
        public static void UseCostomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature.Error;

                    var statusCode = StatusCodes.Status500InternalServerError;

                    switch (exception)
                    {
                        case BadRequestException:
                            statusCode = StatusCodes.Status400BadRequest;
                            break;
                        case NotFoundException:
                            statusCode = StatusCodes.Status404NotFound;
                            break;

                        default:
                            break;
                    }

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;

                    var response = ApiResponse<NoData>.Fail(statusCode, exception.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
