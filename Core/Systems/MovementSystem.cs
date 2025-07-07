using System.Linq;
using EcsTest.Ecs;
using EcsTest.Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace EcsTest.Core.Systems;

public class MovementSystem : IUpdateSystem
{

    public void Update(World world, GameTime gameTime)
    {
        foreach (var entity in world.GetEntitiesWith<Position, Velocity>())
        {
            var position = entity.GetComponent<Position>();
            var velocity = entity.GetComponent<Velocity>();
            position.X += velocity.Dx * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += velocity.Dy * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}