using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
