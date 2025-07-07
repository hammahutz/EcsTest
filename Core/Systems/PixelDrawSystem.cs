using System.Collections.Generic;
using System.Linq;
using EcsTest.Core.Components;
using EcsTest.Ecs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsTest.Core.Systems
{
    public class PixelDrawSystem : IDrawSystem
    {

        public void Draw(World world, SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var entity in world.GetEntitiesWith<Position, Pixel>())
            {
                var position = entity.GetComponent<Position>();
                var pixel = entity.GetComponent<Pixel>();
                spriteBatch.Draw(
                    texture: pixel.Texture,
                    position: new Vector2(position.X, position.Y),
                    sourceRectangle: null,
                    color: Color.White,
                    rotation: 0f,
                    origin: Vector2.Zero,
                    scale: Vector2.One,
                    effects: SpriteEffects.None,
                    layerDepth: 0f
                );
            }
        }
    }
}