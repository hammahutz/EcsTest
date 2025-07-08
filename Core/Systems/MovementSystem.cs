using EcsTest.Ecs;
using EcsTest.Core.Components;
using Microsoft.Xna.Framework;
using System;

namespace EcsTest.Core.Systems;

public class MovementSystem : IUpdateSystem
{
    private float _maxVelocity = 10;

    public void Update(World world, GameTime gameTime)
    {
        foreach (var entity in world.GetEntitiesWith<Position, Movement>())
        {
            var position = entity.GetComponent<Position>();
            var movement = entity.GetComponent<Movement>();

            movement.Velocity = movement.Velocity + movement.Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Coordinate = position.Coordinate + movement.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            var length = movement.Velocity.Length();

            if (MathF.Abs(movement.Velocity.Length()) > _maxVelocity)
            {
                movement.Velocity = new Vector2(movement.Velocity.X / length, movement.Velocity.Y / length);
                movement.Velocity *= _maxVelocity;
            }


            System.Console.WriteLine(position);
            System.Console.WriteLine(movement);
        }
    }
}