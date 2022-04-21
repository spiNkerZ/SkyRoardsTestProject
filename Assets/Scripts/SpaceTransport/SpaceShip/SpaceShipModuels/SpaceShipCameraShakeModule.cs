using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpaceShipCameraShakeModule : SpaceTransportModules
{
    [SerializeField] SpaceShip spaceShip;
    [SerializeField] SpaceShipControl control;

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float boostShakeValue;
    [SerializeField] float crashShakeValue;

    float originalShakeValue;

    bool oldBoost;

    private void Start()
    {
        originalShakeValue = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain;
    }

    public override void OnUpdate()
    {
        BoostShakeCamera();
    }
    public override void OnCrash()
    {
        CrashShakeCamera();
    }

    void CrashShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = crashShakeValue;

        StartCoroutine(LerpShakeCorutine());
        IEnumerator LerpShakeCorutine()
        {
            int delta = 0;
            yield return new WaitForSeconds(1);

            while(originalShakeValue < perlin.m_AmplitudeGain)
            {
                perlin.m_AmplitudeGain = Mathf.Lerp(perlin.m_AmplitudeGain, originalShakeValue, delta * 0.3f);
                delta++;
                yield return null;
            }
        }
    }

    void BoostShakeCamera()
    {
        if (oldBoost == control.boost) return;

        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = control.boost ? boostShakeValue : originalShakeValue;

        oldBoost = control.boost;
    }

   
}
