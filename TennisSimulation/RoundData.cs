using System.Collections.Generic;
using TournamentSimulation.Enums;
using TournamentSimulation.Match;

namespace TournamentSimulation.Data
{
    public struct RoundData
    {
        public readonly SurfaceType SurfaceType;
        public readonly List<PlayerData> PlayersDat;
        public readonly MatchControllerBase MatchControllerBase;
        public RoundData(SurfaceType surfaceType, List<PlayerData> playersDat, MatchControllerBase matchControllerBase)
        {
            SurfaceType = surfaceType;
            this.PlayersDat = playersDat;
            this.MatchControllerBase = matchControllerBase;
        }
    }
}