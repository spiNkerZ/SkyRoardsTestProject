using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaitForSecondsRealtime))]
public class GameManager : MonoBehaviour, IGameStart,IGameOver
{
    public static GameManager instance;
    public bool gameOn;

    private void Awake() => SingeltonInit();
    void Start() => InterfacesInit();

    void SingeltonInit() => instance = this;
    void InterfacesInit()
    {
        InterfaceManager.instance.Add_IStartGameInterface(this);
        InterfaceManager.instance.Add_IGameOverInterface(this);
    }

    public void StartGame() => gameOn = true;
    public void GameOver() => gameOn = false;

}
