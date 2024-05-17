using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StressTest.Api.Database.DbContexts;
using StressTest.Api.Database.EntityModels;
using StressTest.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("stressTestApi", new OpenApiInfo { Version = "v1", Title = "API V1" });
});

// builder.Services.AddStackExchangeRedisOutputCache(options =>
// {
//     options.Configuration = "localhost:6379";
//     options.InstanceName = "WebApiOutputCache";
// });
//
// builder.Services.AddOutputCache(options =>
// {
//     options.AddBasePolicy(policyBuilder =>
//     {
//         policyBuilder.Expire(TimeSpan.FromSeconds(30));
//     });
//     
//     options.AddPolicy("Expire60", policyBuilder =>
//     {
//         policyBuilder.Expire(TimeSpan.FromSeconds(60));
//         policyBuilder.SetVaryByQuery("count");
//     });
// });



builder.Services.AddDbContext<UserEntityDbContext>(options =>
{
    options.UseSqlServer("Data Source=localhost;Initial Catalog=Stress_Test_Db;Integrated Security=true;Encrypt=False");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
  //  app.UseSwaggerUI();
  
  app.MapScalarUi();
}

//app.UseOutputCache();
app.UseHttpsRedirection();

app.MapGet("/ListUsers", async (UserEntityDbContext db) =>
    {
        var users = await db.Users.AsNoTracking().ToListAsync();

        return Results.Ok(users);
    }).WithName("ListUsers")
    .WithOpenApi();
    //.CacheOutput();

    app.MapGet("/ListUsersCount", async (UserEntityDbContext db, int count) =>
        {
            var users = await db.Users.AsNoTracking().Take(count).ToListAsync();

            return Results.Ok(users);
        }).WithName("ListUsersCount")
        .WithOpenApi();
    //.CacheOutput("Expire60");

app.Run();

