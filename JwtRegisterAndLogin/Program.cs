using Application.Buhaviors;
using Application.Exceptions;
using Application.FluentValidationRegister;
using Application.Interfaces;
using Application.MediatRRegister;
using Data;
using Data.Repositories;
using Domain.Models.ApplicationSettings;
using Domain.Models.Common;
using Domain.Models.Entities;
using JwtRegisterAndLogin.Helpers;
using JwtRegisterAndLogin.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StalkersDbContext>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("DatabasePath")!));

builder.Services.AddIdentity<Stalker, IdentityRole<Guid>>(options => {
    options.Password.RequiredLength = 10; //Мінімальна довжина пароля 
    options.Password.RequireNonAlphanumeric = false; //Обов'язкові не алфавітні символи
    options.Password.RequireDigit = false; //Обов'язкові цифри
    options.Password.RequireLowercase = false; //Обов'язкові літери нижнього регістру
    options.Password.RequireUppercase = false; //Обов'язкові літери верхнього регістру

    options.User.RequireUniqueEmail = true; //Обов'язкова унікальна пошта

    options.SignIn.RequireConfirmedEmail = true; //Потрібно підтвердити пошту

    options.Lockout.MaxFailedAccessAttempts = 5; //Максимальна кількість спроб, щоб увійти
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);// Час блокування
    })
    .AddEntityFrameworkStores<StalkersDbContext>()
    .AddDefaultTokenProviders();

MediatRRegister.RegisterAllHandlers(builder.Services); //Конфігуруємо медіатр
FluentValidationRegister.RegisterFluentValidation(builder.Services); // Конфігуруємо валідатор


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //Конфігуруємо маппер

builder.Services.AddSwaggerGen(options => // Підключення JWT Authorization до свагеру
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
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
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthentication(cfg => { //Додаю JWT token
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8
            .GetBytes(builder.Configuration["ApplicationSettings:JWT_Key"]!)
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<IStalkerRepository, StalkersRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IAvatarRepository, AvatarRepository>();
builder.Services.AddScoped<IGroupingRepository, GroupingRepository>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
builder.Services.AddExceptionHandler<GlobalExceptionsHandler>(); // Додаємо глобальний помилковий хендлер
builder.Services.AddProblemDetails(); 
builder.Services.AddHostedService<VerifivationEmailCleaner>(); // Додаємо сервіс, який працює в фоновому режимі 


var app = builder.Build();

app.UseExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
Initialization.SeedData(app);


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
