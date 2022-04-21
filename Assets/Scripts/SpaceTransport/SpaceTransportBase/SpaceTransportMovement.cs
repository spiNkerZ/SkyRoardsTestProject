using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceTransportMovement : MonoBehaviour
{
    public abstract void OnUpdate();
    public virtual void OnSpawn() { }
    public virtual void OnCrash() { }

}
