using System.Text;
using AssignmentApp.API.Repository.Assignments;
using AssignmentApp.API.Repository.Token;
using AssignmentApp.API.Repository.Users;
using AssignmentApp.Data.EF;
using AssignmentApp.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TokenHandler = AssignmentApp.API.Repository.Token.TokenHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme()
    {
        Name = "JWT Authentication",
        Description = "Enter a valid jwt bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference()
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
        
    };
    options.AddSecurityDefinition(securityScheme.Reference.Id,securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement() 
        {
            {securityScheme , new string[] {}}
        }
    );
});

// DI
var connectionString = builder.Configuration.GetConnectionString("AssignmentAppDatabase");
builder.Services.AddDbContext<AssignmentAppDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenHandler, TokenHandler>();
// builder.Services.AddTransient<UserManager<User>, UserManager<User>>();
// builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>();
// builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// builder.Services.AddIdentity<User, AppRole>().AddEntityFrameworkStores<AssignmentAppDbContext>()
//     .AddDefaultTokenProviders();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();