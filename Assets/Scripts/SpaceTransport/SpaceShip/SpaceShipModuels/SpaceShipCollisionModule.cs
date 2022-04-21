using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipCollisionModule : SpaceTransportModules
{
    [SerializeField] SpaceShip spaceShip;

    bool detectedCollision;

    public override void OnSpawn() => detectedCollision = true;
    public override void OnCrash() => detectedCollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (detectedCollision) spaceShip.Crash();
    }

}
