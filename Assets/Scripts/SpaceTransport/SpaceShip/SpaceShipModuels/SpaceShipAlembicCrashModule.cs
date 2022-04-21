using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class SpaceShipAlembicCrashModule : SpaceTransportModules
{
    [SerializeField] SpaceShip spaceShip;
    [SerializeField] AlembicStreamPlayer alembic;

    [SerializeField] float speedAlembicPlay;

    public override void OnSpawn()
    {
        RestoreAnimation();
    }
    public override void OnCrash()
    {
        PlayCrashAnimation();
    }

    void PlayCrashAnimation()
    {
        StartCoroutine(AlembicCrashAnimationCorutine());

        IEnumerator AlembicCrashAnimationCorutine()
        {
            while (alembic.CurrentTime < 1)
            {
                alembic.CurrentTime += speedAlembicPlay * Time.deltaTime;

                yield return null;
            }
        }
    }

    void RestoreAnimation() => alembic.CurrentTime = 0;

}
