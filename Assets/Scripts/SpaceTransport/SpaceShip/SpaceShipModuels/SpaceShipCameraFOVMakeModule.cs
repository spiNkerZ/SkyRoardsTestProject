using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpaceShipCameraFOVMakeModule : SpaceTransportModules
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] SpaceShipControl control;

    [SerializeField] float boostFOVvalue, speedBoostLerp;
    float originalFOVvalue;

    private void Awake()
    {
        originalFOVvalue = virtualCamera.m_Lens.FieldOfView;
    }
    public override void OnUpdate() => BoostFOVcamera();

    void BoostFOVcamera()
    {
        float valueFOV = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, control.boost ? boostFOVvalue : originalFOVvalue, speedBoostLerp);

        virtualCamera.m_Lens.FieldOfView = valueFOV;
    }

    public override void OnCrash()
    {
        virtualCamera.m_Lens.FieldOfView = originalFOVvalue;
    }
}
