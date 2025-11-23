using System.Reflection;

public class SimpleDIContainer
{
    private Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

    public void Register<TInterface, TImplementation>()
    {
        _registrations[typeof(TInterface)] = typeof(TImplementation);
    }

    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }

    private object Resolve(Type type)
    {
        if (!_registrations.ContainsKey(type))
            throw new Exception($"Type {type.FullName} not registered.");

        Type implementationType = _registrations[type];
        ConstructorInfo constructor = implementationType.GetConstructors().First();
        ParameterInfo[] parameters = constructor.GetParameters();

        if (parameters.Length == 0)
            return Activator.CreateInstance(implementationType);

        object[] resolvedParameters = new object[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            resolvedParameters[i] = Resolve(parameters[i].ParameterType);
        }

        return constructor.Invoke(resolvedParameters);
    }
}