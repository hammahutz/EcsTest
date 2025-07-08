
using Microsoft.Xna.Framework;

namespace EcsTest.Core.Components;

public class Movement : Ecs.Component
{
    public Vector2 Velocity { get; set; } = Vector2.Zero;
    public Vector2 Acceleration { get; set; } = Vector2.Zero;
    public Vector2 Fiction { get; set; } = Vector2.Zero;
}