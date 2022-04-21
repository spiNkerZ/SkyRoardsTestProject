using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatisticViewToUImodule : MonoBehaviour
{
    [SerializeField] StatisticManager.StatisticType statsType;
    [SerializeField] TextMeshProUGUI[] tmpTextArray;

    void Start() => StatisticManager.instance.SubscriptionOnStatsUpdate(OnUpdateStats);
    void OnUpdateStats()
    {
        foreach (var item in tmpTextArray) item.text = StatisticManager.instance.GetStats(statsType).ToString();
    }
}
