using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SpaceShipControl))]
[RequireComponent(typeof(SpaceShipMovement))]
public class SpaceShip : SpaceTransportBase
{
    public override void Spawn()
    {
        gameObject.SetActive(true);

        base.Spawn();
    }
    public override void Crash() 
    {
        InterfaceManager.instance.Invoke_IGameOverInterface();

        base.Crash();
    }
}
