namespace TournamentSimulation.Data
{
    public class ExperienceData
    {
        public readonly int WinExperience;
        public readonly int LoserExperience;

        public ExperienceData(int winExperience, int loserExperience)
        {
            this.WinExperience = winExperience;
            this.LoserExperience = loserExperience;
        }
    }
}