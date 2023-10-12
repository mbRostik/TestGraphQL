using _2.Context;
using _2.Models;

namespace _2.GraphQL.UserS
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure (IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Ny tipa useru");

            

            descriptor
                .Field(p => p.Orders)
                .ResolveWith<Resolvers>(p => p.GetOrders(default!, default!))
                .UseDbContext<MyContext>()
                .Description("Orderu useriv");

            descriptor
                .Field(p => p.UserTeam)
                .ResolveWith<Resolvers>(p => p.GetUserTeams(default!, default!))                
                .UseDbContext<MyContext>()
                .Description("Teams usera");

        }

        private class Resolvers
        {
            public IQueryable<Order> GetOrders([Parent] User user, [ScopedService]  MyContext context)
            {
                return context.Orders.Where(p => p.UserId == user.Id);
            }

            public IQueryable<UserTeam> GetUserTeams([Parent] User user, [ScopedService] MyContext context)
            {
                return context.UserTeam.Where(p => p.UserId == user.Id);
            }
        }

      
    }
}
