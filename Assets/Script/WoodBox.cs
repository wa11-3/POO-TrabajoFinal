using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : Box
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
        boxCollider.forceReceiveLayers = LayerMask.GetMask(new string[] { "Default","Player 2", "WoodBox", "StoneBox", "Statue" });
    }

    protected override void SetMass()
    {
        rigidbody.mass = boxObject.WoodMass;
    }
}
