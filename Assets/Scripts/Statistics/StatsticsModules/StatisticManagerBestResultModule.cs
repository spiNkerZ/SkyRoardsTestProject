using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticManagerBestResultModule : MonoBehaviour
{
    int pointsNow, bestResult;

    private void Start()
    {
        StatisticManager.instance.SubscriptionOnStatsUpdate(CheckPointsNow);
        StatisticManager.instance.SubscriptionOnGameOver(GameOver);
    }

    public void RebuildStats()
    {
        pointsNow = 0;

        if (PlayerPrefs.HasKey("TestTask_BestResult"))
        {
            StatisticManager.instance.AddStats(StatisticManager.StatisticType.BestResult, PlayerPrefs.GetInt("TestTask_BestResult"));
        }
        else
        {
            PlayerPrefs.SetInt("TestTask_BestResult", 0);

            StatisticManager.instance.AddStats(StatisticManager.StatisticType.BestResult, 0);
        }

        bestResult = PlayerPrefs.GetInt("TestTask_BestResult");
    }

    void CheckPointsNow()
    {
        pointsNow = StatisticManager.instance.GetStats(StatisticManager.StatisticType.PointsNow);

        if (pointsNow > bestResult)
        {
            StatisticManager.instance.SetStats(StatisticManager.StatisticType.BestResult, pointsNow);
        }
    }

    void GameOver()
    {
        if (pointsNow > bestResult)  PlayerPrefs.SetInt("TestTask_BestResult", pointsNow);
    }
}
