using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UIMouduleBase : MonoBehaviour
{
    private void Start() => InterfaceInit();
    protected abstract void InterfaceInit(); 
    protected abstract void Active();
    protected abstract void Deactive();

}
