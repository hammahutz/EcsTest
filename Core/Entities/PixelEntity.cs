namespace EcsTest.Core.Entities;

using System;
using System.Buffers.Text;
using EcsTest.Core.Components;
using EcsTest.Ecs;
using Microsoft.Xna.Framework.Graphics;

class PixelEntity : Entity
{

    private readonly _components = new();
    public static IComponent[] Create(
        GraphicsDevice graphicsDevice,
        Position position = null,
        Velocity velocity = null,
        Pixel pixel = null)
    {
        if (graphicsDevice == null)
        {
            throw new ArgumentNullException(nameof(graphicsDevice), "GraphicsDevice cannot be null.");
        }

        position = position ?? new Position(0, 0);
        velocity = velocity ?? new Velocity(0, 0);
        pixel = pixel ?? new Pixel(graphicsDevice);
        return [position, velocity, pixel];
    }

    public override IComponent[] CreateEntity(IComponent[] components = null)
    {
        throw new NotImplementedException();
    }
}