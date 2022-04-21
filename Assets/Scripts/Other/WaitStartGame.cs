using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitStartGame : MonoBehaviour, IGameStart
{
    void Update()
    {
        if (Input.anyKey) InterfaceManager.instance.Invoke_IStartGameInterface();
    }

    void Start() => InterfaceInit();
    void InterfaceInit() => InterfaceManager.instance.Add_IStartGameInterface(this);
    public void StartGame() => this.enabled = false;
}
