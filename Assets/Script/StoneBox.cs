using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBox : Box
{
    public override void Start()
    {
        base.Start();
        //boxObject = base.boxObject;
        SetMovement();
        SetMass();
    }


    protected override void SetMovement()
    {
        base.SetMovement();
        boxCollider.forceReceiveLayers = LayerMask.GetMask(new string[] { "Default", "Player 1", "StoneBox", "Statue" });
    }

    protected override void SetMass()
    {
        rigidbody.mass = boxObject.StoneMass;
    }
}
