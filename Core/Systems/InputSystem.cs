using EcsTest.Core.Components;
using EcsTest.Ecs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EcsTest.Core.Systems;

public class InputSystem : IUpdateSystem
{
    // public enum Direction { East, NorthEast, North, NorthWest, West, SouthWest, South, SouthEast }
    private Vector2 _direction = new Vector2();
    private float _magnitude = 1;
    public void Update(World world, GameTime gameTime)
    {
        var state = Keyboard.GetState();

        if (state.IsKeyDown(Keys.Left))
            _direction = new Vector2(-1, _direction.Y);
        if (state.IsKeyDown(Keys.Up))
            _direction = new Vector2(_direction.X, 1);
        if (state.IsKeyDown(Keys.Right))
            _direction = new Vector2(1, _direction.Y);
        if (state.IsKeyDown(Keys.Down))
            _direction = new Vector2(_direction.X, -1);

        _direction.Normalize();

        System.Console.WriteLine(_direction);


        foreach (var entity in world.GetEntitiesWith<Acceleration>())
        {
            var acceleration = entity.GetComponent<Acceleration>();

            acceleration.Dx += _direction.X * _magnitude * (float)gameTime.ElapsedGameTime.TotalSeconds;
            acceleration.Dy += _direction.Y * _magnitude * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }


    }
}