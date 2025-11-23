namespace TournamentSimulation.Serializer
{
    public interface IDeserializer<T>
    {
        T Deserialize();
    }
}
