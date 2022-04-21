using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntitySpawner))]
public class EntityManager : MonoBehaviour, IGameStart
{
    [SerializeField] EntitySpawner spawner;

    void Start() => InterfacesInit();
    void InterfacesInit() => InterfaceManager.instance.Add_IStartGameInterface(this);
    public void StartGame() => spawner.Spawn();
}
