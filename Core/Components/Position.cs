namespace EcsTest.Core.Components;

public class Position : Ecs.IComponent
{
    public float X { get; set; }
    public float Y { get; set; }

    public Position(float x, float y)
    {
        X = x;
        Y = y;
    }

    public Position() : this(0, 0) { }

    public override string ToString() => $"Position(X: {X}, Y: {Y})";
}