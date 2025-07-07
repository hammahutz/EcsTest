using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsTest.Ecs;

public interface IDrawSystem
{
    void Draw(World world, SpriteBatch spriteBatch, GameTime gameTime);
}
