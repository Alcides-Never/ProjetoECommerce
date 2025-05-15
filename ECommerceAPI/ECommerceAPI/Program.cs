using System.Text;
using ECommerceAPI.Context;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// O .NET vai criar os objetos(Inje��o de Dependencia)
//T"r�s jeitos de inje��o
// AddTransient -> O C# criar uma inst�ncia nova, toda vez que um m�todo � chamado.- Bastante utilizado
// AddScoped -> O C# cria uma inst�ncia nova, toda vez que criar um Controller. - Pouco usado devido ao risco de conflito. De modo geral cria um repositoria para ser usado diversas vezes, diferente do AddTransient
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

//Aplica��o do Cors, a linha Cors precisa estar sempre acima do m�todo mapControllers. Se colocar depois ele n�o ir� funcionar pois a aplica��o ir� criar o controller antes de aplicar as pol�ticas.
app.UseCors("minhasOrigens");

app.UseSwagger();

app.UseSwaggerUI();


app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();