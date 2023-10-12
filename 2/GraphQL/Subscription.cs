using _2.Models;

namespace _2.GraphQL
{
    public class Subscription
    {

        [Subscribe]
        [Topic]
        public User OnUser([EventMessage] User user) => user;

        [Subscribe]
        [Topic]
        public Order OnOrderAdded([EventMessage] Order order) => order;

        [Subscribe]
        [Topic]
        public Team OnTeamAdded([EventMessage] Team team) => team;


        [Subscribe]
        [Topic]
        public UserTeam OnUserTeamAdded([EventMessage] UserTeam UserTeam) => UserTeam;
    }
}
