using TournamentSimulation.Enums;

namespace TournamentSimulation.Data
{
    public struct TournamentData
    {
        public int Id { get; set; }
        public SurfaceType Surface { get; set; }
        public TournamentType Type { get; set; }
        public ExperienceData Experience { get; set; }
    }
}