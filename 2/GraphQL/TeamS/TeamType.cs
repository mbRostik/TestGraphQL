using _2.Context;
using _2.Models;

namespace _2.GraphQL.TeamS
{

    public class TeamType : ObjectType<Team>
    {
        protected override void Configure(IObjectTypeDescriptor<Team> descriptor)
        {
            descriptor.Description("Ny tipa teams");

            descriptor
                .Field(p => p.UserTeam)
                .ResolveWith<Resolvers>(p => p.GetUserTeams(default!, default!))
                .UseDbContext<MyContext>()
                .Description("Useru timu i pymbu");


        }

        private class Resolvers
        {
            public IQueryable<UserTeam> GetUserTeams([Parent] Team team, [ScopedService] MyContext context)
            {
                return context.UserTeam.Where(p => p.TeamId == team.Id);
            }
        }
    }
}