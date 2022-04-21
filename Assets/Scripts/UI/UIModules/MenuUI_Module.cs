using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI_Module : UIMouduleBase,IGameStart
{
    [SerializeField] Transform menuRoot;

    protected override void InterfaceInit()
    {
        InterfaceManager.instance.Add_IStartGameInterface(this);
    }
    public void StartGame() => Deactive();

    protected override void Active() => menuRoot.gameObject.SetActive(true);
    protected override void Deactive() => menuRoot.gameObject.SetActive(false);

   
}
