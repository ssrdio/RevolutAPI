using RevolutAPI.AutomaticCardPayment.Features.AutomaticPayment;
using RevolutAPI.AutomaticCardPayment.Features.Customers;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.DAO;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Database;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RevolutSettings>(builder.Configuration.GetSection("RevolutSettings"));
builder.Services.AddDbContext<CustomersDBContext>();
builder.Services.AddTransient<CustomersDAO>();
builder.Services.AddTransient<CustomersPaymentMethodsDAO>();
builder.Services.AddTransient<AutomaticChargeDAO>();
builder.Services.AddScoped<AutomaticPaymentService>();
builder.Services.AddScoped<CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    CustomersDBContext context = scope.ServiceProvider.GetRequiredService<CustomersDBContext>();
    context.Database.EnsureCreated();
    context.SaveChanges();
    
}


app.UseAuthorization();

app.MapControllers();

app.Run();
