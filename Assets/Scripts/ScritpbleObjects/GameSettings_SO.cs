using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings",menuName = "ScriptableObject/GameSettings")]
public class GameSettings_SO : ScriptableObject
{
  [Range(0,5)] public float startGameAfterSpawn;
  [Range(0,5)] public float speedGame;
  [Range(0,30)] public float clampSides;

}
