using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager instance;
    event Action eventIStartGame,eventIGameOver;

    private void Awake()
    {
        SingeltonInit();
    }

    void SingeltonInit() => instance = this;

    public void Add_IStartGameInterface(IGameStart _realization) => eventIStartGame += _realization.StartGame;
    public void Add_IGameOverInterface(IGameOver _realization) => eventIGameOver += _realization.GameOver;

    public void Invoke_IStartGameInterface() => eventIStartGame.Invoke();
    public void Invoke_IGameOverInterface() => eventIGameOver.Invoke();

}
