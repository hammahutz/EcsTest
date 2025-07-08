namespace EcsTest.Core.Entities;
using EcsTest.Core.Components;
using EcsTest.Ecs;
using Microsoft.Xna.Framework;

class PixelEntity : Entity
{
    public PixelEntity(Pixel pixel, Position position = null)
    {
        AddComponent(pixel);
        AddComponent(position ?? new Position() { Coordinate = new Vector2(100, 100)});
        AddComponent(new Movement());
    }
}