using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class SpaceTransportBase : MonoBehaviour
{
    [SerializeField] protected SpaceTransportMovement movement;
    [SerializeField] protected SpaceTransportControl control;
    [SerializeField] protected SpaceTransportModules[] modules;

    public event Action onCrash, onSpawn;

    private void Awake()
    {
        SubscribeToOnSpawnEvent();
        SubscribeToOnCrashEvent();
    }

    public virtual void Spawn() => onSpawn?.Invoke();
    public virtual void Crash() => onCrash?.Invoke();

    protected virtual void Update()
    {
        movement.OnUpdate();
        control.OnUpdate();

        if (modules.Length > 0) ModulesUpdate();
    }

    void ModulesUpdate()
    {
        foreach (var item in modules) item.OnUpdate();
    }
    void SubscribeToOnSpawnEvent()
    {
        onSpawn += movement.OnSpawn;
        onSpawn += control.OnSpawn;

        foreach (var item in modules) onSpawn += item.OnSpawn;
    }
    void SubscribeToOnCrashEvent()
    {
        onCrash += movement.OnCrash;
        onCrash += control.OnCrash;

        foreach (var item in modules) onCrash += item.OnCrash;
    }

}
