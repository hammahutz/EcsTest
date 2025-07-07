using EcsTest.Ecs;
using EcsTest.Core.Components;
using Microsoft.Xna.Framework;

namespace EcsTest.Core.Systems;

public class MovementSystem : IUpdateSystem
{

    public void Update(World world, GameTime gameTime)
    {
        foreach (var entity in world.GetEntitiesWith<Position, Velocity, Acceleration>())
        {
            var position = entity.GetComponent<Position>();
            var velocity = entity.GetComponent<Velocity>();
            var acceleration = entity.GetComponent<Acceleration>();

            velocity.Dx += acceleration.Dx * (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity.Dy += acceleration.Dy * (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X += velocity.Dx * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += velocity.Dy * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}