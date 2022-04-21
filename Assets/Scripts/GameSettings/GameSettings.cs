using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SetScreenSettings))]
public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;
    public GameSettings_SO settings;

    public float gameSpeed 
    {  
        get 
        {
           return gameSpeed_S.boost ? settings.speedGame * gameSpeed_S.speed * gameSpeed_S.speedMultiplay : settings.speedGame * gameSpeed_S.speed; 
        }
    }
    public struct GameSpeed
    {
        public bool boost;
        public float speed;
        public float speedMultiplay;
    }
    GameSpeed gameSpeed_S;

    void Awake() => SingeltonInit();
    void SingeltonInit() => instance = this;
    public void SetGameSpeed(GameSpeed _gameSpeed) => gameSpeed_S = _gameSpeed;
}
