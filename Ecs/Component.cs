using System.Linq;

namespace EcsTest.Ecs;

public abstract class Component
{
    public override string ToString()
    {
        var name = GetType().Name;
        var properties = GetType()
            .GetProperties()
            .Select(p => $"{p.Name}: {p.GetValue(this)}")
            .Aggregate((a, b) => $"{a}, {b}");

        return $"{name} {properties}";
    }
}