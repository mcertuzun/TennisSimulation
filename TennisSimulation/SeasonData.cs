using System.Collections.Generic;

namespace TournamentSimulation.Data
{
    public struct SeasonData
    {
        public List<PlayerData> Players { get; set; }
        public List<TournamentData> Tournaments { get; set; }
    } 
}