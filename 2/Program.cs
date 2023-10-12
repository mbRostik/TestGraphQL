using _2.Context;
using _2.GraphQL;
using Microsoft.EntityFrameworkCore;
using _2.GraphQL.UserS;
using _2.GraphQL.OrderS;
using _2.GraphQL.UserTeamS;
using _2.GraphQL.TeamS;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<MyContext>(opt => opt.UseSqlServer
(builder.Configuration.GetConnectionString("SQLServer")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()    
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    .AddType<OrderType>()
    .AddType<UserType>()
    .AddType<TeamType>()
    .AddType<UserTeamType>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.UseRouting();
app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
    endpoints.MapGraphQLVoyager();
});

app.Run();
