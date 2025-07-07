
namespace EcsTest.Core.Components;

public class Velocity : Ecs.IComponent
{
    public float Dx { get; set; }
    public float Dy { get; set; }

    public Velocity(float dX, float dY)
    {
        Dx = dX;
        Dy = dY;
    }

    public override string ToString() => $"Velocity(Dx: {Dx}, Dy: {Dy})";
}