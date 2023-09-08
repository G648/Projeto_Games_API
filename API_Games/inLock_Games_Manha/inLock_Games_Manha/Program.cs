using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servi�o de Controller
builder.Services.AddControllers();

//Adiciona servi�o de Jwt Bearer (forma de autentica��o)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";

})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem esta solicitando
        ValidateIssuer = true,

        //Valida quem esta recebendo
        ValidateAudience = true,

        //define se o tempo de expira��o sera validado
        ValidateLifetime = true,

        //forma de criptografia e valida a chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-autenticacao-inLock-Games")),

        //Valida o tempo de expira��o do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //nome do audience (para onde est� indo)
        ValidIssuer = "inLock_Games_Manha",

        ValidAudience = "inLock_Games_Manha"
    };
});

//adiciona o gerador do swagger � cole��o de servi�os
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes",
        Description = "Uma ASP.NET Core WEB API para gerenciamento de filmes",
        Contact = new OpenApiContact
        {
            Name = "Guilherme Amorim",
            Url = new Uri("https://github.com/")
        }
    });

    // Configura o swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autentica�ao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

//Come�a a configura��o do swagger
//Habilita o middleware para entender ao documento JSON gerado e � interface do usu�rio do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Para atender � interface do usu�rio do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//Finaliza a configura��o do swagger

//Adicona mapeamento dos controllers
app.MapControllers();

//Adiciona autentica��o
app.UseAuthentication();

//Adiciona autoriza��o
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();