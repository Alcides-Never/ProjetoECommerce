using System.Text;
using ECommerceAPI.Context;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Repositories;
using Microsoft.IdentityModel.Tokens;

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

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "ecommerce",
            ValidAudience = "ecommerce",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai"))
        };
    });

builder.Services.AddAuthentication();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name: "minhasOrigens",
            policy =>
            {
                //TODO: Alterar o link para o Frontend
                policy.WithOrigins("http://localhost:5500");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            }
        );
    });

var app = builder.Build();

//Aplicação do Cors, a linha Cors precisa estar sempre acima do método mapControllers. Se colocar depois ele não irá funcionar pois a aplicação irá criar o controller antes de aplicar as políticas.
app.UseCors("minhasOrigens");

app.UseSwagger();

app.UseSwaggerUI();


app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();