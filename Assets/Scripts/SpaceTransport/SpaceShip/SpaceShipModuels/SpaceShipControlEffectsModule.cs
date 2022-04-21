using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControlEffectsModule : SpaceTransportModules
{
    [SerializeField] SpaceShip spaceShip;
    [SerializeField] SpaceShipControl control;

    [SerializeField] ParticleSystem[] engineEffectsArray;
    [SerializeField] float boostSizeEngineEffects;
    float startSizeEngineEffects;
    bool oldBoostValue;

    private void Awake()
    {
        startSizeEngineEffects = engineEffectsArray[0].main.startSize.constant;
    }

    public override void OnUpdate()
    {
        ControlEngineEffects();
    }

    void ControlEngineEffects()
    {
        if (oldBoostValue == control.boost) return;

        foreach (var item in engineEffectsArray)
        {
            Debug.Log("BOOOST");
            var sizeEngineEffect = item.main;
            sizeEngineEffect.startSize = control.boost ? boostSizeEngineEffects : startSizeEngineEffects;

            oldBoostValue = control.boost;
        }
    }
    public override void OnSpawn()
    {
        foreach (var item in engineEffectsArray) item.Play();
    }
    public override void OnCrash()
    {
        foreach (var item in engineEffectsArray) item.Stop();
    }

}
