using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSoundsModule : SpaceTransportModules
{
    [SerializeField] AudioSource sounds;
    [SerializeField] SpaceShip spaceShip;
    [SerializeField] SpaceShipControl control;

    [SerializeField] float boostPitchValue;
    float originalPitchValueOnRun;

    bool oldBoostValue;

    [SerializeField] AudioClip crashSound;

    private void Awake() => originalPitchValueOnRun = sounds.pitch;
    public override void OnSpawn() => sounds.Play();
    public override void OnUpdate() => BoostControlSoundsPitch();

    void BoostControlSoundsPitch()
    {
        if (oldBoostValue == control.boost) return;

        sounds.pitch = control.boost ? boostPitchValue : originalPitchValueOnRun;
        oldBoostValue = control.boost;
    }

    public override void OnCrash()
    {
        sounds.Stop();
        sounds.PlayOneShot(crashSound);
    }
}
