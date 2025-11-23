using TournamentSimulation.Enums;

namespace TournamentSimulation.Data
{
    public struct MatchData
    {
        public MatchData(PlayerData player, PlayerData opponent, SurfaceType surface)
        {
            Player = player;
            Opponent = opponent;
            Surface = surface;
        }
        public PlayerData Player { get; set; }
        public PlayerData Opponent { get; set; }
        public SurfaceType Surface { get; set; }
        public override string ToString()
        {
            return $" {Player} VS {Opponent} ";
        }
    }
}