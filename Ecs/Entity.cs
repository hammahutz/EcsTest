using System;
using System.Collections.Generic;
using System.Runtime;

namespace EcsTest.Ecs;

public abstract class Entity
{
    private static long _nextId = 0;
    private readonly Dictionary<Type, Component> _components = new();
    public long Id { get; private set; }

    public Entity() => Id = _nextId++;


    public override string ToString() => $"Entity(Id: {Id}";

    public Entity AddComponent<T>(T component) where T : Component
    {
        Type type = component.GetType();
        if (_components.ContainsKey(type))
        {
            throw new InvalidOperationException($"Component of type {type} already exists on this entity.");
        }
        _components[type] = component;
        return this;
    }

    public T GetComponent<T>() where T : Component
    {
        if (_components.TryGetValue(typeof(T), out var component))
        {
            return (T)component;
        }
        throw new KeyNotFoundException($"Component of type {typeof(T)} not found on this entity.");
    }
    public bool HasComponent<T>(T component) where T : Type
    {
        if (component == null)
        {
            return _components.ContainsKey(typeof(T));
        }
        return _components.ContainsKey(component);
    }
    public void RemoveComponent<T>() where T : Component
    {
        if (!_components.Remove(typeof(T)))
        {
            throw new KeyNotFoundException($"Component of type {typeof(T)} not found on this entity.");
        }
    }
    public void ClearComponents()
    {
        _components.Clear();
    }

    public int ComponentCount => _components.Count;

    public bool IsEmpty => _components.Count == 0;

}
