using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipStatsTimeAssemblingModule : SpaceTransportModules
{
    [SerializeField] SpaceShipControl control;
    bool calculateOn;

    public override void OnSpawn()
    {
        calculateOn = true;
        StartCoroutine(CalculateTime());
    }

    IEnumerator CalculateTime()
    {
        int countPointsForAdd = 0;

        while(calculateOn)
        {
            countPointsForAdd = control.boost ? StatisticManager.instance.settings.countPointsBoostOnOneSecondGame : StatisticManager.instance.settings.countPointsOnOneSecondGame;

            StatisticManager.instance.AddStats(StatisticManager.StatisticType.TimeInGame, countPointsForAdd);
            StatisticManager.instance.AddStats(StatisticManager.StatisticType.PointsNow, countPointsForAdd);

            yield return new WaitForSeconds(1);
        }
    }

    public override void OnCrash()
    {
        calculateOn = false;
    }
}
