using Microsoft.AspNetCore.Authorization;
using MinimalApiCatalogo.Models;
using MinimalApiCatalogo.Services;

namespace MinimalApiCatalogo.ApiEndpoints;
    public static class AutenticacaoEndpoints
    {
        public static void MapAutenticacaoEndpoints(this WebApplication app)
        {
            app.MapPost("/login", [AllowAnonymous] (UserModel model, ITokenService tokenService) =>
            {
                if (model == null)
                {
                    return Results.BadRequest("Login Inválido");
                }
                if (model.UserName == "victor" && model.Password == "numsey#123")
                {
                    var tokenString = tokenService.GerarToken(
                        app.Configuration["Jwt:Key"],
                        app.Configuration["Jwt:Issuer"],
                        app.Configuration["Jwt:Audience"],
                        model);

                    return Results.Ok(new { token = tokenString });
                }
                else
                {
                    return Results.BadRequest("Login inválido");
                }
            }).Produces(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status200OK)
              .WithName("Login")
              .WithTags("Autenticacao");
        }

    }
