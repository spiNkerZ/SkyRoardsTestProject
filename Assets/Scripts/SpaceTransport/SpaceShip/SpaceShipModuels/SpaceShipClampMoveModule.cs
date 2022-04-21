using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipClampMoveModule : SpaceTransportModules
{
    public override void OnUpdate()
    {
        Vector3 clampVector = transform.position;
        clampVector.x = Mathf.Clamp(clampVector.x, -GameSettings.instance.settings.clampSides, GameSettings.instance.settings.clampSides);

        transform.position = clampVector;
    }
}
