using youTobeProject.DataBase;
using youTobeProject.Domain;

namespace youTobeProject.ConsoleApp
{
    internal class Program
    {
        private static FootballLegueContext context = new FootballLegueContext();
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team> {
                new Team
                {
                    Name = "Barselona",
                    LeagueId = 1
                },
                new Team
                {
                    Name = "Juventus",
                    LeagueId = 1
                },
                new Team
                {
                    Name = "Real Madrid",
                    LeagueId = 1
                },
            };
            context.AddRange(teams);
            context.SaveChanges();
        }
    }
}
