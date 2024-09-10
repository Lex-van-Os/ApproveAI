using ApproveAiBusiness.Factories;
using ApproveAiBusiness.Repositories;
using ApproveAiBusiness.UnitOfWork;
using ApproveAiModels;
using ApproveAiModels.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Configuration of OData models
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<User>("User");
modelBuilder.EntitySet<Group>("Group");
modelBuilder.EntitySet<Role>("Role");
modelBuilder.EntitySet<ApprovalWorkflow>("ApprovalWorkflow");
modelBuilder.EntitySet<ApprovalRequest>("ApprovalRequest");
modelBuilder.EntitySet<ApprovalStep>("ApprovalStep");
modelBuilder.EntitySet<RegisteredAnswer>("RegisteredAnswer");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration for (generic) controller functionality
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
builder.Services.AddHttpClient();

// Configuration of the database context
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuration of OData controllers
builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));

var app = builder.Build();

try
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();

        await DatabaseSeeder.SeedAsync(context);
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred while seeding the database:");
    Console.WriteLine(ex.Message);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
