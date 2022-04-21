using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControl : SpaceTransportControl
{
    [SerializeField] SpaceShipMovement movement;

    Vector3 direction;
    public bool boost { private set; get; }

    public override void OnUpdate()
    {
        boost = Input.GetKey(KeyCode.Space);
        direction = Vector3.right * Input.GetAxis("Horizontal");

        movement.SetMove(direction);
        movement.SetBoost(boost);
    }

    public override void OnSpawn() => this.enabled = true;
    public override void OnCrash() => this.enabled = false;
}
