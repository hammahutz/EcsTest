using Microsoft.Xna.Framework;

namespace EcsTest.Core.Components;

public class Position : Ecs.Component
{
    public Vector2 Coordinate { get; set; } = Vector2.Zero;
}