using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float jumpLength = 15f;
    [SerializeField] private LayerMask ground;

    
    private Collider2D coll;

    private bool facingLeft = true;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        //transition form jump to fall
        if (anim.GetBool("Jumping"))
        {
            if (rb.velocity.y < .1)
            {
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);
            }
        }

        //transition form fall to idle
        if (coll.IsTouchingLayers(ground) && anim.GetBool("Falling"))
        {
            anim.SetBool("Falling", false);
        }

    }

    private void Move()

    {
        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.CompareTag("Cross"))
        {
            Physics2D.IgnoreCollision(collison.collider, coll);
        }
    }
}
