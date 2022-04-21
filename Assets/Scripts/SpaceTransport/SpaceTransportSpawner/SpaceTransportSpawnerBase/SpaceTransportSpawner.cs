using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceTransportSpawner : MonoBehaviour
{
    [SerializeField] [Range(0,5)] protected float delaySpawnAfterStart;

    private void Start() => InterfaceInit();
    protected abstract void InterfaceInit();
    protected abstract void Spawn();

}
