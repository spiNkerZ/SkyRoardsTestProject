using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceShipControlPreset", menuName = "ScriptableObject/SpaceShip/SpaceShipControlPreset")]
public class SpaceShipControl_SO : ScriptableObject
{
    public KeyCode Right, Left;
}
