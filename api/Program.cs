using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Services.Interfaces;
using api.Services.Implementations;
using api.Repositories.Interfaces;
using api.Repositories.Implementations;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using api.Settings;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UCReviewsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UCReviewsDatabase")));
// Contact Elliott for necessary JWT config and DB access info

// Add configuration related
builder.Services.Configure<PaginationSettings>(builder.Configuration.GetSection("Pagination"));

// Add service layer dependencies to the container
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IDormService, DormService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<IParkingGarageService, ParkingGarageService>();
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<IDiningHallService, DiningHallService>();


// Add repository layer dependencies to the container
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IDormRepository, DormRepository>();
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<IParkingGarageRepository, ParkingGarageRepository>();
builder.Services.AddTransient<IDiningHallRepository, DiningHallRepository>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"])
            )
        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UsePathBase(new PathString("/api"));

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
