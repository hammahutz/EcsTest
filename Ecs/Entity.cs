using System;
using System.Collections.Generic;
using System.Runtime;

namespace EcsTest.Ecs;

public abstract class Entity
{
    private static long _nextId = 0;
    private readonly Dictionary<Type, IComponent> _components = new();
    public long Id { get; private set; }

    protected Entity(IComponent[] components = null)
    {
        Id = _nextId++;
        if (components != null)
        {
            foreach (var component in components)
            {
                AddComponent(component);
            }
        }
    }

    private void AddEntityToWorld()
    {
        CreateEntity(/)
    }
    public abstract IComponent[] CreateEntity();

    public override string ToString() => $"Entity(Id: {Id}";

    public Entity AddComponent<T>(T component) where T : IComponent
    {
        Type type = component.GetType();
        if (_components.ContainsKey(type))
        {
            throw new InvalidOperationException($"Component of type {type} already exists on this entity.");
        }
        _components[type] = component;
        return this;
    }

    public T GetComponent<T>() where T : IComponent
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
    public void RemoveComponent<T>() where T : IComponent
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
    public IEnumerable<IComponent> GetAllComponents()
    {
        return _components.Values;
    }

    public int ComponentCount => _components.Count;

    public bool IsEmpty => _components.Count == 0;

}
