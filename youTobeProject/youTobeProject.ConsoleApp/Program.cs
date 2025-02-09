using youTobeProject.DataBase;

namespace youTobeProject.ConsoleApp
{
    internal class Program
    {
        private static FootballLegueContext context = new FootballLegueContext();
        static void Main(string[] args)
        {
            //var leagues = (from i in context.Teams
            //               where i.LeagueId == 3
            //               select i).ToList();
            //foreach (var league in leagues)
            //{
            //    Console.WriteLine(league.Name);
            //}
            //Team team = new Team() { Id = 1, Name = "Ajax", LeagueId = 2, };
            //context.Teams.Update(team);
            //context.SaveChanges();

            var league = context.Leagues.Find(1);
            context.Leagues.Remove(league);
            context.SaveChanges();
        }
    }
}
