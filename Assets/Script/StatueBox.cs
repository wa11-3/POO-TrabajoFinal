using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueBox : Box
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
        boxCollider.forceReceiveLayers = LayerMask.GetMask(new string[] { "Default", "Player 1", "Player 2" });
    }

    protected override void SetMass()
    {
        rigidbody.mass = boxObject.TotemMass;
    }
}
