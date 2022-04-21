using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenSettings : MonoBehaviour
{
    private void Awake() => SetScreenSizeDefault();
    void SetScreenSizeDefault() => Screen.SetResolution(1920, 1080, true);
}
