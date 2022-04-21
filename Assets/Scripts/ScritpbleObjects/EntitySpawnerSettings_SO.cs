using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntitySpawnSettings", menuName = "ScriptableObject/EntitySpawnSettings")]
public class EntitySpawnerSettings_SO : ScriptableObject
{
    [Range(0, 50)] public int countSpawn;

    [Range(10,500)] public float distSpawnOnStartByTarget;
    [Range(0, 100)] public float wigthSpawn;
    [Range(0, 100)] public float minDistBetweenEntites;
    [Range(0, 100)] public float maxDistBetweenEntites;
    [Range(-10,10)] public float YOffset;
    [Range(0, 100)] public float distByTargetForReplace;

}
