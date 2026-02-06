using System.Reflection;
using CalculatorDomain.Logic;
using CalculatorDomain.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

var dataDirectory = Path.Combine(
    builder.Environment.ContentRootPath,
    "Data"
);

builder.Services.AddSingleton<ICalculationStore>(
    new FileCalculationStore(dataDirectory)
);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite("Data source = Calculator.db")); //Use same name for database
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();






builder.Services.AddControllers(); //tells ASP.NET that this application will use controllers as entry points
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICalculationStore>(
    new FileCalculationStore(dataDirectory)
);
builder.Services.AddSingleton<CalculatorService>();

builder.Services.AddScoped<TokenService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(options =>
{
    var jwt = builder.Configuration.GetSection("Jwt");

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwt["Issuer"],
        ValidAudience = jwt["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Jwt:Key"])
    )

    };
})
;


var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var role = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    await IdentitySeeder.SeedAsync(userManager, roleManager);
}

//Must add middleware between build and controller


app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();



app.Run();

