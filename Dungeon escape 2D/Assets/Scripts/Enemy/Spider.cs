using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    //Initialisation
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void movement()
    {
        base.movement();

    }

    public void damage()
    {
        Debug.Log("Palyer Hit Spider");

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
