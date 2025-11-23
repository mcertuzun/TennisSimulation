using TournamentSimulation.Data;

namespace TournamentSimulation.Tournament
{
    public class SeasonController
    {
        private readonly SeasonData _seasonData;

        public SeasonController(SeasonData seasonData)
        {
            _seasonData = seasonData;
        }

        public void StartSeason()
        {
            var players = _seasonData.Players;
            var season = _seasonData.Tournaments;
            foreach (var tournamentData in season)
            {
                var tournamentController = TournamentFactory.CreateTournamentController(tournamentData, players);
                tournamentController.StartTournament();
            }
        }
    }
}

