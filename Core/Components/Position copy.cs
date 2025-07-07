namespace EcsTest.Core.Components;

public class Size : Ecs.IComponent
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Size(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public Size() : this(0, 0) { }

    public override string ToString() => $"Size(Width: {Width}, Height: {Height})";
}