using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(StatisticDataBase))]
[RequireComponent(typeof(StatisticManagerBestResultModule))]
public class StatisticManager : MonoBehaviour,IGameStart,IGameOver
{
    public enum StatisticType { TimeInGame, AsteooidsFinished, PointsNow, BestResult }

    public static StatisticManager instance;
    public StatisticSettings_SO settings;

    [SerializeField] StatisticDataBase statisticDB;
    [SerializeField] StatisticManagerBestResultModule bestResultModule;

    event Action eventStatsUpdate, eventGameOver;

    void Awake() => SingeltonInit();
    void Start() => InterfacesInit();
    
    void SingeltonInit() => instance = this;
    void InterfacesInit()
    {
        InterfaceManager.instance.Add_IGameOverInterface(this);
        InterfaceManager.instance.Add_IStartGameInterface(this);
    }

    public void SetStats(StatisticManager.StatisticType _type, int _count)
    {
        statisticDB.SetStats(_type, _count);
    }
    public void AddStats(StatisticManager.StatisticType _type, int _count)
    {
        eventStatsUpdate.Invoke();
        statisticDB.AddStats(_type, _count);
    }
    public int GetStats(StatisticManager.StatisticType _type)
    {
        return statisticDB.GetStatsByType(_type);
    }
    public void SubscriptionOnStatsUpdate(Action _func) => eventStatsUpdate += _func;
    public void SubscriptionOnGameOver(Action _func) => eventGameOver += _func;

    public void StartGame()
    {
        //PlayerPrefs.SetInt("TestTask_BestResult", 0);
        statisticDB.RebuildBase();
        bestResultModule.RebuildStats();
    }
    public void GameOver()
    {
        eventGameOver.Invoke();
    }
}
