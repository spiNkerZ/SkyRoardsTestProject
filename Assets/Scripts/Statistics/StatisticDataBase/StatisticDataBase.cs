using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatisticDataBase : MonoBehaviour
{
    Dictionary<StatisticManager.StatisticType, byte[]> statisticDict = new System.Collections.Generic.Dictionary<StatisticManager.StatisticType, byte[]>();

    public void SetStats(StatisticManager.StatisticType _type, int _count)
    {
        if (!statisticDict.ContainsKey(_type)) statisticDict.Add(_type, BitConverter.GetBytes(0));
        statisticDict[_type] = BitConverter.GetBytes(_count);
    }
    public void AddStats(StatisticManager.StatisticType _type, int _count)
    {
        if (!statisticDict.ContainsKey(_type)) statisticDict.Add(_type, BitConverter.GetBytes(0));
        statisticDict[_type] = BitConverter.GetBytes(BitConverter.ToInt32(statisticDict[_type], 0) + _count);
    }

    public int GetStatsByType(StatisticManager.StatisticType _type)
    {
        if (!statisticDict.ContainsKey(_type)) return 0;
        return BitConverter.ToInt32(statisticDict[_type], 0);
    }

    public void RebuildBase() => statisticDict = new Dictionary<StatisticManager.StatisticType, byte[]>();
}
