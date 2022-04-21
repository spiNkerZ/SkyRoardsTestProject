using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] EntityBase[] entityArrayForSpawn;

    [SerializeField] Transform target, spawnedEntityParent;

    List<EntityBase> entitySpawnedArray = new List<EntityBase>();

    public void Spawn() => CreateEntites();
    void CreateEntites()
    {
        if (CheckOnSpawnedEntityAndSetPos()) return;

        int countsForCreate = 0;
        
        foreach (var entityForSpawn in entityArrayForSpawn)
        {
            countsForCreate = entityForSpawn.spawnSettings.countSpawn;

            for (int i = 0; i < countsForCreate; i++)
            {
                entitySpawnedArray.Add(Instantiate(entityForSpawn));
                entitySpawnedArray[i].entityID = i;
                entitySpawnedArray[i].transform.parent = spawnedEntityParent;

                InstallPosition(entitySpawnedArray[i], entityForSpawn.spawnSettings);
            }
        }
    }

    bool CheckOnSpawnedEntityAndSetPos()
    {
        bool spawned = entitySpawnedArray.Count > 0;
        if (spawned)
        {
            foreach (var spawnedEntity in entitySpawnedArray)
            {
                InstallPosition(spawnedEntity, spawnedEntity.spawnSettings);
            }
        }

        return spawned;
    }

    private void Update()
    {
        if (GameManager.instance.gameOn)
        {
            foreach (var entity in entitySpawnedArray)
            {
                float posZ = entity.transform.position.z + entity.spawnSettings.distByTargetForReplace;

                if (posZ < target.position.z)
                {
                    InstallPosition(entity, entity.spawnSettings);

                    if (entity as SpaceAsteroidEntity)
                    {
                        StatisticManager.instance.AddStats(StatisticManager.StatisticType.AsteooidsFinished, 1);
                        StatisticManager.instance.AddStats(StatisticManager.StatisticType.PointsNow, StatisticManager.instance.settings.countsPointsOnFinishedOneAsteroid);
                    }
                }
                else
                {
                    UpdatePosition(entity, entity.spawnSettings);
                }

                entity.OnUpdate();
            }
        }
    }

    void InstallPosition(EntityBase _entity,EntitySpawnerSettings_SO _entitySettings)
    {
        _entity.transform.position = Vector3.forward * _entitySettings.distSpawnOnStartByTarget * 2;
        Vector3 offsetPos = Vector3.zero;
        offsetPos.x = Random.Range(-_entitySettings.wigthSpawn, _entitySettings.wigthSpawn);
        offsetPos.y = _entitySettings.YOffset;
        offsetPos.z = _entity.entityID * Random.Range(_entitySettings.minDistBetweenEntites, _entitySettings.maxDistBetweenEntites);

        _entity.transform.position += offsetPos;
    }

    void UpdatePosition(EntityBase _entity, EntitySpawnerSettings_SO _entitySettings)
    {
        _entity.transform.Translate(-Vector3.forward * GameSettings.instance.gameSpeed * Time.deltaTime,Space.World);
    }

}
