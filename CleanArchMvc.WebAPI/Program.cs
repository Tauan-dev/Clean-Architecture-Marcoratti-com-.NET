using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços de infraestrutura
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Teste de conexão com o banco de dados
Console.WriteLine("Iniciando teste de conexão...");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Conexão ao banco de dados bem-sucedida!");
        }
        else
        {
            Console.WriteLine("Falha ao conectar ao banco de dados.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao tentar conectar ao banco de dados: {ex.Message}");
    }
}

Console.WriteLine("Teste de conexão finalizado.");

// Configura o pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();  // Mapeia as rotas dos controladores

app.Run();
