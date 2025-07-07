using EcsTest.Core.Components;
using EcsTest.Core.Entities;
using EcsTest.Core.Systems;
using EcsTest.Ecs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EcsTest;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private World _world;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        _world = new World()
            .AddSystem(new PixelDrawSystem())
            .AddSystem(new MovementSystem())
            .AddSystem(new InputSystem())
            .CreateEntity(new PixelEntity(new Pixel(GraphicsDevice, 10, 10), new Position(100f, 100f)));
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
            || Keyboard.GetState().IsKeyDown(Keys.Q)
        )
            Exit();
        _world.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _world.Draw(_spriteBatch, gameTime);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
