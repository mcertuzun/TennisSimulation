using System.Collections.Generic;
using System;
using TournamentSimulation.Data;
using TournamentSimulation.Enums;
using TournamentSimulation.Match;
using TournamentSimulation.Round;

namespace TournamentSimulation.Tournament
{
    public static class TournamentFactory
    {
        public static TournamentControllerBase CreateTournamentController(TournamentData tournamentData, List<PlayerData> players)
        {
            switch (tournamentData.Type)
            {
                case TournamentType.Elimination:
                    return EliminationSetup(tournamentData, players);
                case TournamentType.League:
                    return LeagueSetup(tournamentData, players);
                default:
                    throw new ArgumentException("Invalid service type");
            }
        }
        private static TournamentControllerBase LeagueSetup(TournamentData tournamentData, List<PlayerData> players)
        {
            tournamentData.Experience = new ExperienceData(10, 1);
            IMatchController matchController = new NormalMatchController(tournamentData.Experience);
            IRoundController roundController = new LeagueRoundController(tournamentData.Surface, players, matchController);
            return new LeagueTournamentController(players, tournamentData, roundController);
        }
        private static TournamentControllerBase EliminationSetup(TournamentData tournamentData, List<PlayerData> players)
        {
            tournamentData.Experience = new ExperienceData(20, 10);
            IMatchController matchController = new NormalMatchController(tournamentData.Experience);
            IRoundController roundController = new EliminationRoundController(tournamentData.Surface, players, matchController);
            return new EliminationTournamentController(players, tournamentData, roundController);
        }
    }
}