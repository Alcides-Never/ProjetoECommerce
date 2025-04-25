using ECommerceAPI.Context;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// O .NET vai criar os objetos(Injeção de Dependencia)
//T"rês jeitos de injeção
// AddTransient -> O C# criar uma instância nova, toda vez que um método é chamado.- Bastante utilizado
// AddScoped -> O C# cria uma instância nova, toda vez que criar um Controller. - Pouco usado devido ao risco de conflito. De modo geral cria um repositoria para ser usado diversas vezes, diferente do AddTransient
// AddSingleton
builder.Services.AddDbContext<EcommerceContext, EcommerceContext>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();


var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();


app.MapControllers();

app.Run();