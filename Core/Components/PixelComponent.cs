using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsTest.Core.Components;

public class Pixel : Ecs.IComponent
{
    private GraphicsDevice _graphicsDevice;
    private int width = 1;
    private int height = 1;

    public Texture2D Texture { get; set; }
    public int Width
    {
        get => width;
        set
        {
            bool success = UpdateSize(value, Height);
            if (success)
            {
                width = value;
            }
            else
            {
                throw new ArgumentException("Width must be a positive integer above zero.");
            }
        }
    }
    public int Height
    {
        get => height;
        set
        {
             bool success = UpdateSize(Width, value);
            if (success)
            {
                height = value;
            }
            else
            {
                throw new ArgumentException("Width must be a positive integer above zero.");
            }
        }
    }

    public Pixel(GraphicsDevice graphicsDevice, int width = 1, int height = 1)
    {
        _graphicsDevice = graphicsDevice;
        Width = width;
        Height = height;
    }

    private bool UpdateSize(int width, int height)
    {
        if (width <= 0 || height <= 0)
        {
            return false;
        }

        // Recreate the texture with the new size
        Texture = new Texture2D(_graphicsDevice, width, height);
        var colorData = new Color[width * height];
        for (int i = 0; i < colorData.Length; i++)
        {
            colorData[i] = Color.White; // Fill with white color
        }
        Texture.SetData(colorData);

        return true;
    }

    public override string ToString() => $"Pixel(Width: {Width}, Y: {Height})";
}