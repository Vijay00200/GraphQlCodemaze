using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQlCodemaze.Contracts;
using GraphQlCodemaze.Entities.Context;
using GraphQlCodemaze.Entities.GraphQL.GraphQLSchema;
using GraphQlCodemaze.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(opt =>
       opt.UseSqlite(builder.Configuration.GetConnectionString("sqlConString")));

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<AppSchema>();
builder.Services.AddGraphQL()
    .AddSystemTextJson()
    .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped)
    .AddDataLoader();

builder.Services.AddControllers()
            .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGraphQL<AppSchema>();
app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

app.MapControllers();

app.Run();
