using CleanArchMvc.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços de infraestrutura
builder.Services.AddInfrastructure(builder.Configuration);

// Adiciona os controladores (se necessário)
builder.Services.AddControllers();

// Adiciona o Swagger (se necessário para documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();  // Mapeia as rotas dos controladores

app.Run();
