using TournamentSimulation.Data;
using TournamentSimulation.Serializer;
using TournamentSimulation.Tournament;


internal class Program
{
    private static void Main(string[] args)
    {
        SeasonData seasonData = new JsonDeserializer<SeasonData>("input.json").Deserialize();
        SeasonController seasonController = new SeasonController(seasonData);
        seasonController.StartSeason();
    }
}