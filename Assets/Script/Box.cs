using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    protected BoxObject boxObject;

    protected string layerName;
    protected string boxType;

    protected BoxCollider2D boxCollider;
    protected Rigidbody2D rigidbody;

    public virtual void Start()
    {
        //Debug.Log(boxObject.TotemMass);
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void SetMovement() { }
    protected virtual void SetMass() { }
}
