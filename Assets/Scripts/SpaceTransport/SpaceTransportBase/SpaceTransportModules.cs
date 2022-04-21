using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceTransportModules : MonoBehaviour
{
    public virtual void OnUpdate() { }
    public virtual void OnSpawn() { }
    public virtual void OnCrash() { }
}
