using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sr;

    public virtual void Init()
    {
        currentTarget = Vector3.zero;
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }
    public void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        movement();
    }

    public virtual void movement()
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
