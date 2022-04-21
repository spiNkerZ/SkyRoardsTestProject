using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCatEntity : EntityBase
{
    [SerializeField][Range(0, 5)] float speedRotate;

    Vector3 dirRotation;

    private void Start() => dirRotation[Random.Range(0, 2)] = 1;
    public override void OnUpdate() => transform.Rotate(dirRotation * speedRotate);
}
