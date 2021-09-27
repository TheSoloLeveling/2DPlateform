using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    //Initialisation
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void damage()
    {
        Debug.Log("Skeleton Hit");

        Health--;
        anim.SetTrigger("Hit");
        isHit = true;

        anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            Destroy(gameObject);
        }

    }
}
