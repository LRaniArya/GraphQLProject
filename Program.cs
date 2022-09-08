using GraphQL;
using GraphiQl;
using GraphQL.SystemTextJson;
using GraphQL.AspNetCore3;
using GraphQL.Types;
using GraphQLProjectCode.Types;
using GraphQLProjectCode.Interface;
using GraphQLProjectCode.Services;
using GraphQLProjectCode.Schema;
using GraphQLProjectCode.Queries;
using GraphQL.MicrosoftDI;
using GraphQL.Server.Ui.Playground;
using GraphQLProjectCode.Mutation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Dependencies
builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<ProductQuery>();
builder.Services.AddSingleton<ProductMutation>();
builder.Services.AddSingleton<ISchema, ProductSchema>();


builder.Services.AddGraphQL(b => b
    .AddGraphTypes(typeof(Program).Assembly)
    .AddSchema<ProductSchema>()
    .AddSystemTextJson()   // serializer
);

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

app.UseGraphQL("/graphql");
//app.UseGraphiQl("/graphql");
app.UseGraphQLPlayground(
    "/");   // url to host Playground at


app.Run();
