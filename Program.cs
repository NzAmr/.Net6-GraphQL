using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.GraphQL.Commands;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddPooledDbContextFactory<AppDbContext>( options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr"));
});
builder.Services.AddGraphQLServer()
.AddQueryType<Query>()
.AddMutationType<Mutation>()
.AddSubscriptionType<Subscription>()
.AddType<PlatformType>()
.AddType<CommandType>()
.AddFiltering()
.AddSorting()
.AddProjections()
.AddInMemorySubscriptions();

var app = builder.Build();
app.UseWebSockets();
app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.MapGraphQL();
});
app.UseGraphQLVoyager("/graphql-voyager");

app.Run();
