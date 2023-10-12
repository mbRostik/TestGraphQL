using _2.Context;
using _2.Models;

namespace _2.GraphQL.OrderS
{
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor.Description("Ny tipa orderu");

            descriptor
                .Field(p => p.User)
                .ResolveWith<Resolvers>(p => p.GetUsers(default!, default!))
                .UseDbContext<MyContext>()
                .Description("Order usera");
        }

        private class Resolvers
        {
            public User GetUsers([Parent] Order order, [ScopedService] MyContext context)
            {
                return context.Users.FirstOrDefault(p => p.Id == order.UserId);
            }
        }
    }
}
