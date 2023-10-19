using ArangoDB.Client;
using Arangodbcompany.Model;
using Arangodbcompany.Repository.IRepository;
using Arangodbcompany.Repository;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var arangoConfig = builder.Configuration.GetSection("ArangoDB");
var arangodbsetting = arangoConfig.Get<Arangodbsetting>();
var databaseSheardsaetting = new DatabaseSharedSetting
{
    Url = arangodbsetting.ServerUrl,
    Database = arangodbsetting.DatabaseName,
    Credential = new NetworkCredential(arangodbsetting.Username, arangodbsetting.Password)
};
IArangoDatabase arangoDatabase = new ArangoDatabase(databaseSheardsaetting);
builder.Services.AddSingleton(arangoDatabase);
builder.Services.AddScoped<Iemployeerepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentrepository, Departmentrepository>();
builder.Services.AddScoped<IWorkonrepository, WorkonRepository>();

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
