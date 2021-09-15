using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerAnimation anim;
    private SpriteRenderer sr;

    [SerializeField]
    private float jump = 5.0f;
    [SerializeField]
    private float speed = 3.0f;
    private bool resetJump = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<PlayerAnimation>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckGrounded();
        
    } 

    void Movement()
    {
        float moveH = Input.GetAxisRaw("Horizontal");

        if (moveH < 0)
            sr.flipX = true;
        else if (moveH > 0)
            sr.flipX = false;

        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
 
            StartCoroutine(ResetJumpRoutine());
        }

        rb.velocity = new Vector2(moveH * speed, rb.velocity.y);
        anim.Move(moveH);
    }

    bool CheckGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 6);

        if (hitInfo.collider != null)
        {
            if (!resetJump)
                return true;
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
}
