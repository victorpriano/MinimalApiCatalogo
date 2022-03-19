using MinimalApiCatalogo.ApiEndpoints;
using MinimalApiCatalogo.AppServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAuthenticationJwt();

var app = builder.Build();

//Endpoint para login
app.MapAutenticacaoEndpoints();

//Endpoints Categorias
app.MapCategoriaEndpoints();

//Endpoints Produtos
app.MapProdutoEndpoints();

//app.MapGet("/", () => "Ol� mundo! 2022").ExcludeFromDescription(); // exclui da exibi��o dos endpoints no swagger

var environment = app.Environment;
app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

