using System;
using Microsoft.Xna.Framework;

namespace EcsTest.Ecs;

public interface IUpdateSystem
{
    void Update(World world, GameTime gameTime);
}
