using Microsoft.EntityFrameworkCore;
using rjp_test.Data;
using rjp_test.IServices;
using rjp_test.Models;
using rjp_test.Services;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase("rjpDb"));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
