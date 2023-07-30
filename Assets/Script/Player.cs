using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int layer;

    private Animator animator;

    public bool playerOne;
    private KeyCode[] _controlsKey;
    private KeyCode[] _controlsOneKey = { KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S, KeyCode.Space };
    private KeyCode[] _controlsTwoKey = { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.Return};

    private List<Collider2D> nearObjects = new List<Collider2D>();
    private BoxCollider2D boxCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        if (playerOne)
        {
            _controlsKey = _controlsOneKey;
        }
        else
        {
            _controlsKey = _controlsTwoKey;
        }
    }

    private void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(_controlsKey[0]))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(_controlsKey[1]))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(_controlsKey[2]))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(_controlsKey[3]))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
        //GetComponent<Rigidbody2D>().AddForce(speed * dir);

        if (Input.GetKeyDown(_controlsKey[4]))
        {
            foreach (Collider2D nearObject in nearObjects)
            {
                if (nearObject.TryGetComponent(out IPowerable powerable))
                {
                    //Debug.Log(powerable.power);
                    powerable.SetPowerUp();
                    StartCoroutine(PowerUp(powerable.power));
                }
            }
        }
    }

    private IEnumerator PowerUp(string power)
    {
        switch (power)
        {
            case "ghost":
                //boxCollider.excludeLayers = ~0;
                boxCollider.excludeLayers = LayerMask.GetMask(new string[] { "Player 1", "Player 2", "WoodBox", "StoneBox"});
                yield return new WaitForSeconds(5.0f);
                boxCollider.excludeLayers = 0;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.transform.name);
        nearObjects.Add(collision);
        //nearObject = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nearObjects.Remove(collision);
    }
}
