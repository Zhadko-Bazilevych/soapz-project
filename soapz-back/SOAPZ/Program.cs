global using SOAPZ.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SOAPZ.Operations.BookInfo;
using SOAPZ.Services;
using System.Text;
using System.Text.Json.Serialization;
using SOAPZ.Operations.Books;
using SOAPZ.Operations.Reservation;
using SOAPZ.Operations.StatusUpdate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddHttpClient();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<ReservationService>();

builder.Services.AddIdentityCore<User>(y =>
{
    y.Password.RequiredLength = 4;
    y.Password.RequireLowercase = false;
    y.Password.RequireNonAlphanumeric = false;
})  .AddEntityFrameworkStores<DataContext>()
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
//using var scope = app.Services.CreateScope();
//var context = scope.ServiceProvider.GetRequiredService<DataContext>();
//await context.Database.MigrateAsync();

app.UseCors(policy =>
{
    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
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
