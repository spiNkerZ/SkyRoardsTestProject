using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeUtilites : MonoBehaviour
{
    public static void PosAndRotToTarget(object _entity,Transform _target)
    {
        (_entity as MonoBehaviour).transform.SetPositionAndRotation(_target.position, _target.rotation);
    }
}
