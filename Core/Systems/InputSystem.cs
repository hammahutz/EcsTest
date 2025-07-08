using System.Collections.Generic;
using EcsTest.Core.Components;
using EcsTest.Ecs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EcsTest.Core.Systems;

public class InputSystem : IUpdateSystem
{
    // public enum Direction { East, NorthEast, North, NorthWest, West, SouthWest, South, SouthEast }
    private float _magnitude = 10;
    public void Update(World world, GameTime gameTime)
    {
        var state = Keyboard.GetState();

        Vector2 direction = new Vector2(0, 0);
        if (state.IsKeyDown(Keys.Left))
            direction = new Vector2(-1, direction.Y);
        if (state.IsKeyDown(Keys.Up))
            direction = new Vector2(direction.X, -1);
        if (state.IsKeyDown(Keys.Right))
            direction = new Vector2(1, direction.Y);
        if (state.IsKeyDown(Keys.Down))
            direction = new Vector2(direction.X, 1);

        if (direction.X != 0 || direction.Y != 0)
        {
            direction.Normalize();
            direction *= _magnitude;
        }

        foreach (var entity in world.GetEntitiesWith<Movement>())
        {
            var movement = entity.GetComponent<Movement>();
            movement.Acceleration = direction;
        }

    }
}