using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : SpaceTransportMovement
{
    [SerializeField] SpaceShip spaceShip;
    [SerializeField] Rigidbody rigidBody;

    [Header("Move settings")]
    [SerializeField] float speed;
    [SerializeField] float multiplaySpeed;

    [Header("Lurch settings")]
    [SerializeField] float lurchAngle;
    [SerializeField] float lurchSpeed;
    [SerializeField] float lurchSmoothe;

    Vector3 direction, targetPos;
    Quaternion targetRot;

    bool isBoost;

    public override void OnSpawn()
    {
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.rotation = Quaternion.identity;
    }

    public void SetMove(Vector3 _direction) => direction = _direction;
    public void SetBoost(bool _boost) => isBoost = _boost;

    public override void OnUpdate()
    {
        targetPos.x = direction.x * lurchSpeed;
        if (isBoost) targetPos.x *= multiplaySpeed;

        targetRot = Quaternion.AngleAxis((direction.x * lurchAngle), -transform.forward);

        rigidBody.velocity = targetPos;
        rigidBody.MoveRotation(Quaternion.Lerp(transform.rotation, targetRot, lurchSmoothe));

        GameSettings.instance.SetGameSpeed(new GameSettings.GameSpeed { boost = isBoost, speed = speed, speedMultiplay = multiplaySpeed });
    }
}
