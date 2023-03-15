global using SOAPZ_Account.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SOAPZ_Account.Operations.Login;
using SOAPZ_Account.Operations.Logout;
using SOAPZ_Account.Operations.Register;
using SOAPZ_Account.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<RegisterOperation>();
builder.Services.AddScoped<LoginOperation>();
builder.Services.AddScoped<LogoutOperation>();

builder.Services.AddIdentityCore<User>(y =>
{
    y.Password.RequiredLength = 4;
    y.Password.RequireLowercase = false;
    y.Password.RequireNonAlphanumeric = false;
}).AddRoles<IdentityRole>()
  .AddEntityFrameworkStores<DataContext>()
  .AddSignInManager<SignInManager<User>>();
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]));
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(y =>
    {
        y.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddScoped<TokenService>();
var app = builder.Build();

app.UseCors(policy =>
{
    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
