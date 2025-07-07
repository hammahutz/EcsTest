
namespace EcsTest.Core.Components;

public class Acceleration : Ecs.IComponent
{
    public float Dx { get; set; }
    public float Dy { get; set; }

    public Acceleration(float dX, float dY)
    {
        Dx = dX;
        Dy = dY;
    }

    public override string ToString() => $"Acceleration(Dx: {Dx}, Dy: {Dy})";
}