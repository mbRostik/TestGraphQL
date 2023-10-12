using _2.Context;
using _2.Models;

namespace _2.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(MyContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([ScopedService] MyContext context)
        {
            return context.Users;
        }
        
        [UseDbContext(typeof(MyContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Order> GetOrders([ScopedService] MyContext context)
        {
            return context.Orders;
        }

        [UseDbContext(typeof(MyContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<UserTeam> GetUserTeam([ScopedService] MyContext context)
        {
            return context.UserTeam;
        }

        [UseDbContext(typeof(MyContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Team> GetTeam([ScopedService] MyContext context)
        {
            return context.Teams;
        }
    }
}
