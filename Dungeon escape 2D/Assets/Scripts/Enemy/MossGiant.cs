using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 currentTarget;
    private Animator anim;
    private SpriteRenderer sr;

    public void Start()
    {
        currentTarget = Vector3.zero;
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }
    public override void Attack()
    {

    }

    public override void Update()
    {
        if (currentTarget == pointA.position)
        {
            sr.flipX = true;
        }
        else if (currentTarget == pointB.position)
        {
            sr.flipX = false;
        }

        if (transform.position == pointA.position) 
        {
            anim.SetTrigger("Idle");
            currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            anim.SetTrigger("Idle");
            currentTarget = pointA.position;
        }

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        
    
    }
}
