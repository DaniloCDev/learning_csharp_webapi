using MongoSettings.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configura o repositório
builder.Services.AddScoped<PostRepository>();

// Configura as configurações do MongoDB
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

// Configura o Swagger
builder.Services.AddSwaggerGen(options =>
{
    // Config Swagger
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "My notes/posting",
        Version = "v1",
        Description = "API para acessar , criar, e deletar , posts armazenados no MongoDB"
    });
});

// Adiciona suporte à API OpenAPI (Swagger)
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
    // Habilita o Swagger na versão de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API notes/posting");
        c.RoutePrefix = string.Empty; // Define a URL raiz para o Swagger UI
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
