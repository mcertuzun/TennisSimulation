using TournamentSimulation.Data;
using TournamentSimulation.Match;
using TournamentSimulation.Tournament;

namespace TournamentSimulation.DI;

public static class Startup
{
    private static SimpleDIContainer _container;

    public static void Initialize()
    {
        _container = new SimpleDIContainer();
        RegisterDependencies();
    }
    private static void RegisterDependencies()
    {
        _container.Register<Random,Random>();
        _container.Register<ExperienceData, ExperienceData>();
        _container.Register<TournamentData, TournamentData>();
        _container.Register<MatchControllerBase, NormalMatchController>();
        _container.Register<MatchControllerBase, LeagueTournamentController>(); 
        //_container.Register<ITournamentFactory, TournamentFactory>();
    }
    public static TService Resolve<TService>()
    {
        return _container.Resolve<TService>();
    }
}