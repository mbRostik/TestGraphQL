using _2.Context;
using _2.Models;
using HotChocolate;
using HotChocolate.Types;

namespace _2.GraphQL.UserTeamS
{
    public class UserTeamType : ObjectType<UserTeam>
    {
        protected override void Configure(IObjectTypeDescriptor<UserTeam> descriptor)
        {
            descriptor.Description("Ia zabyv");

            descriptor
                .Field(p => p.User)
                .ResolveWith<Resolvers>(p => p.GetUser(default!, default!))
                .UseDbContext<MyContext>()
                .Description("Mne len");

            descriptor
                .Field(p => p.Team)
                .ResolveWith<Resolvers>(p => p.GetTeam(default!, default!))
                .UseDbContext<MyContext>()
                .Description("Mne len");
        }

        private class Resolvers
        {
            public User GetUser([Parent] UserTeam userTeam, [ScopedService] MyContext context)
            {
                return context.Users.FirstOrDefault(u => u.Id == userTeam.UserId);
            }

            public Team GetTeam([Parent] UserTeam userTeam, [ScopedService] MyContext context)
            {
                return context.Teams.FirstOrDefault(t => t.Id == userTeam.TeamId);
            }
        }
    }
}