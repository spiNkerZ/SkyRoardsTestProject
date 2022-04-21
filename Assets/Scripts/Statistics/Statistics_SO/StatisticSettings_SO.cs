using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatisticSettingsPreset", menuName = "ScriptableObject/StatisticSettingsPreset")]
public class StatisticSettings_SO : ScriptableObject
{
    public int countPointsOnOneSecondGame;
    public int countPointsBoostOnOneSecondGame;
    public int countsPointsOnFinishedOneAsteroid;

}
