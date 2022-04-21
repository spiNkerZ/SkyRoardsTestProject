using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBase : MonoBehaviour
{
      public EntitySpawnerSettings_SO spawnSettings;
      public int entityID;
   
      public abstract void OnUpdate();
}
