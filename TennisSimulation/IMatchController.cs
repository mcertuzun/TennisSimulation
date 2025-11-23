using TournamentSimulation.Data;

namespace TournamentSimulation.Match
{
    public interface IMatchController
    {
        PlayerData Play(MatchData data);
    }
}

