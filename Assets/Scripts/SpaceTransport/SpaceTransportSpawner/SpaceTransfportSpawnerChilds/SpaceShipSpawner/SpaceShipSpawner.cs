using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSpawner : SpaceTransportSpawner,IGameStart
{
    [SerializeField] SpaceShip spaceShipForSpawn;
    [SerializeField] Transform startPoint;

    protected override void InterfaceInit()
    {
        InterfaceManager.instance.Add_IStartGameInterface(this);
    }

    protected override void Spawn()
    {
        CodeUtilites.PosAndRotToTarget(spaceShipForSpawn, startPoint);
        spaceShipForSpawn.Spawn();
    }

    public void StartGame() => Invoke(nameof(Spawn), delaySpawnAfterStart);
}
