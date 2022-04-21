using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStatisicModule : UIMouduleBase,IGameStart,IGameOver
{
    [SerializeField] Transform statisticRoot;

    protected override void InterfaceInit()
    {
        InterfaceManager.instance.Add_IStartGameInterface(this);
        InterfaceManager.instance.Add_IGameOverInterface(this);
    }

    public void StartGame() => Active();
    public void GameOver() => Deactive();

    protected override void Active() => statisticRoot.gameObject.SetActive(true);
    protected override void Deactive() => statisticRoot.gameObject.SetActive(false);


}
