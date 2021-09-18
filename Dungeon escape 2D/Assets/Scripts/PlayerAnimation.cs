using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;
    private Animator swordAnim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentsInChildren<Animator>()[0];
        swordAnim = GetComponentsInChildren<Animator>()[1];

    }

    public void Move(float move)
    {
        if (anim != null)
        {
            anim.SetFloat("Move", Mathf.Abs(move));
        }
    }

    public void Jump(bool jumping)
    {
        anim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        swordAnim.SetTrigger("SwordAnimation");
    }
}
