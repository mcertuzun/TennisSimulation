using System.Collections.Generic;
using TournamentSimulation.Enums;

namespace TournamentSimulation.Data
{
    public class PlayerData
    {
        public PlayerData(int id, string hand, int experience, Dictionary<SurfaceType, int> skills)
        {
            Id = id;
            Hand = hand;
            Experience = experience;
            Skills = skills;
        }
        private int Id { get; set; }
        public string Hand { get; set; }
        public int Experience { get; set; }
        public Dictionary<SurfaceType,int> Skills{ get; set; }
        public override string ToString()
        {
            return $"Id: {Id} ";
        }
    }
}