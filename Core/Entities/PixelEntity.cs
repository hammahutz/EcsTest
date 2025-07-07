namespace EcsTest.Core.Entities;

using System;
using System.Buffers.Text;
using EcsTest.Core.Components;
using EcsTest.Ecs;
using Microsoft.Xna.Framework.Graphics;

class PixelEntity : Entity
{
    public PixelEntity(Pixel pixel, Position position = null)
    {
        AddComponent(pixel).
        AddComponent(position ?? new Position(100, 100)).
        AddComponent(new Acceleration(1, 1)).
        AddComponent(new Velocity(0, 0));
    }
}