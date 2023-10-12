using _2.Context;
using _2.GraphQL.UserS;
using _2.Models;
using _2.GraphQL.OrderS;
using HotChocolate.Subscriptions;

namespace _2.GraphQL
{
    
    public class Mutation
    {
        [UseDbContext(typeof(MyContext))]
        public async Task<UserPayload> AddUserAsync(AddUserInput input, [ScopedService] MyContext context, [Service] ITopicEventSender eventSender, CancellationToken token)
        {
            var user = new User
            {
                Name = input.name,
                Email = input.email
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnUser), user, token);

            return new UserPayload(user);

        }

        [UseDbContext(typeof(MyContext))]
        public async Task<UserPayload> UpdateUserAsync(UpdateUserInput input, [ScopedService] MyContext context, [Service] ITopicEventSender eventSender, CancellationToken token)
        {
            var user = new User
            {
                Id = input.id,
                Name = input.name,
                Email = input.email
            };

            context.Users.Update(user);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnUser), user, token);

            return new UserPayload(user);

        }


        [UseDbContext(typeof(MyContext))]
        public async Task<UserPayload> DeleteUserAsync(DeleteUserInput input, [ScopedService] MyContext context, [Service] ITopicEventSender eventSender, CancellationToken token)
        {
            var user = context.Users.Where(p => p.Id == input.id).FirstOrDefault();

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnUser), user, token);

            return new UserPayload(user);

        }

        [UseDbContext(typeof(MyContext))]
        public async Task<AddOrderPayload> AddOrderAsync(AddOrderInput input, [ScopedService] MyContext context, [Service] ITopicEventSender eventSender, CancellationToken token)
        {
            var order = new Order
            {
                Name = input.name,
                Description = input.description,
                UserId= input.userId
            };

            context.Orders.Add(order);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnOrderAdded), order, token);

            return new AddOrderPayload(order);

        }
        [UseDbContext(typeof(MyContext))]
        public async Task<AddTeamPayload> AddTeamAsync(AddTeamInput input, [ScopedService] MyContext context, [Service] ITopicEventSender eventSender, CancellationToken token)
        {
            var team = new Team
            {
                Name = input.name
            };

            context.Teams.Add(team);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnTeamAdded), team, token);

            return new AddTeamPayload(team);

        }

        [UseDbContext(typeof(MyContext))]
        public async Task<AddUserTeamPayload> AddUserTeamAsync(AddUserTeamInput input, [ScopedService] MyContext context, [Service] ITopicEventSender eventSender, CancellationToken token)
        {
            var userteam = new UserTeam
            {
                UserId= input.userId,
                TeamId= input.teamId
            };

            context.UserTeam.Add(userteam);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnUserTeamAdded), userteam, token);

            return new AddUserTeamPayload(userteam);

        }

    }
}
