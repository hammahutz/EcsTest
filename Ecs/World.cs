using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsTest.Ecs;

public class World
{
    private readonly List<Entity> _entities = new List<Entity>();
    private readonly List<IUpdateSystem> _updateSystems = new List<IUpdateSystem>();
    private readonly List<IDrawSystem> _drawSystems = new List<IDrawSystem>();

    public World CreateEntity(Entity entity)
    {
        _entities.Add(entity);
        return this;
    }

    public void RemoveEntity(Entity entity)
    {
        if (!_entities.Remove(entity))
        {
            throw new KeyNotFoundException($"Entity with ID {entity.Id} not found in the world.");
        }
    }

    public World AddSystem<T>(T system)
    {
        bool isAdded = false;
        if (system is IUpdateSystem updateSystem)
        {
            _updateSystems.Add(updateSystem);
            isAdded = true;
        }
        if (system is IDrawSystem drawSystem)
        {
            _drawSystems.Add(drawSystem);
            isAdded = true;
        }
        if (!isAdded)
        {
            throw new InvalidOperationException("System must implement either IUpdateSystem or IDrawSystem.");
        }

        return this;

    }

    public void AddUpdateSystem(IUpdateSystem system)
    {
        _updateSystems.Add(system);
    }
    public void RemoveUpdateSystem(IUpdateSystem system)
    {
        if (!_updateSystems.Remove(system))
        {
            throw new KeyNotFoundException("Update system not found in the world.");
        }
    }
    public void AddDrawSystem(IDrawSystem system)
    {
        _drawSystems.Add(system);
    }
    public void RemoveDrawSystem(IDrawSystem system)
    {
        if (!_drawSystems.Remove(system))
        {
            throw new KeyNotFoundException("Draw system not found in the world.");
        }
    }
    public void Update(GameTime gameTime)
    {
        foreach (var system in _updateSystems)
        {
            system.Update(this, gameTime);
        }
    }
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        foreach (var system in _drawSystems)
        {
            system.Draw(this, spriteBatch, gameTime);
        }
    }

    public IEnumerable<Entity> GetEntitiesWith<T1>() where T1 : IComponent => GetEntitiesWith([typeof(T1)]);
    public IEnumerable<Entity> GetEntitiesWith<T1, T2>() where T1 : IComponent where T2 : IComponent => GetEntitiesWith([typeof(T1), typeof(T2)]);
    public IEnumerable<Entity> GetEntitiesWith<T1, T2, T3>() where T1 : IComponent where T2 : IComponent where T3 : IComponent => GetEntitiesWith([typeof(T1), typeof(T2), typeof(T3)]);
    public IEnumerable<Entity> GetEntitiesWith<T1, T2, T3, T4>() where T1 : IComponent where T2 : IComponent where T3 : IComponent where T4 : IComponent => GetEntitiesWith([typeof(T1), typeof(T2), typeof(T3), typeof(T4)]);
    public IEnumerable<Entity> GetEntitiesWith<T1, T2, T3, T4, T5>() where T1 : IComponent where T2 : IComponent where T3 : IComponent where T4 : IComponent where T5 : IComponent => GetEntitiesWith([typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)]);
    public IEnumerable<Entity> GetEntitiesWith<T1, T2, T3, T4, T5, T6>() where T1 : IComponent where T2 : IComponent where T3 : IComponent where T4 : IComponent where T5 : IComponent where T6 : IComponent => GetEntitiesWith([typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6)]);

    private IEnumerable<Entity> GetEntitiesWith(Type[] components)
    {
        foreach (var entity in _entities)
        {
            bool hasAllComponents = false;
            foreach (var component in components)
            {
                if (entity.HasComponent(component))
                {
                    hasAllComponents = true;
                }
                else
                {
                    hasAllComponents = false;
                    break;
                }
            }
            if (hasAllComponents)
            {
                yield return entity;
            }
        }
    }
}