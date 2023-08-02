using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TotemsBox : Box, IPowerable
{
    [SerializeField]
    private string _powerUp;
    public string power { get => _powerUp; set => _powerUp = value; }
    public GameObject Glow;

    //public Collider2D nearObject;

    public override void Start()
    {
        base.Start();
        //boxObject = base.boxObject;
        SetMovement();
        SetMass();
    }

    private void Update()
    {
        
    }

    protected override void SetMovement()
    {
        base.SetMovement();
        boxCollider.forceReceiveLayers = LayerMask.GetMask(new string[] { "Default" });
    }

    protected override void SetMass()
    {
        rigidbody.mass = boxObject.TotemMass;
    }

    public void SetPowerUp()
    {
        StartCoroutine(ActivateAniPowerUp());
    }

    public IEnumerator ActivateAniPowerUp()
    {
        Glow.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        Glow.SetActive(false);
    }
}
