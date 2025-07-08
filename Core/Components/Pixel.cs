using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsTest.Core.Components;

public class Pixel : Ecs.Component
{
    private GraphicsDevice _graphicsDevice;
    private int width = 1;
    private int height = 1;
    private Color color = Color.White;

    public Texture2D Texture { get; private set; }

    public int Width
    {
        get => width;
        set
        {
            if (value >= 0)
            {
                width = value;
                UpdatePixel();
            }
        }
    }

    public int Height
    {
        get => height;
        set
        {
            height = value;
            UpdatePixel();
        }
    }

    public Color Color
    {
        get => color;
        set
        {
            color = value;
            UpdatePixel();
        }
    }

    public Pixel(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
        UpdatePixel();
    }

    private void UpdatePixel()
    {
        Texture = new Texture2D(_graphicsDevice, Width, Height);
        var colorData = new Color[Width * Height];
        for (int i = 0; i < colorData.Length; i++)
        {
            colorData[i] = Color; // Fill with white color
        }
        Texture.SetData(colorData);
    }
}