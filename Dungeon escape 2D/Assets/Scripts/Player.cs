using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerAnimation playerAnim;
    private SpriteRenderer playerSr;
    private SpriteRenderer swordSr;

    [SerializeField]
    private float jump = 5.0f;
    [SerializeField]
    private float speed = 3.0f;
    private bool resetJump = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<PlayerAnimation>();
        rb = GetComponent<Rigidbody2D>();
        playerSr = GetComponentsInChildren<SpriteRenderer>()[0];
        swordSr = transform.GetChild(1).GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckGrounded();
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && CheckGrounded())
        {
            float moveH = Input.GetAxisRaw("Horizontal");
            
            if (playerSr.flipX)
            {
                swordSr.flipX = true;
                swordSr.flipY = true;

                Vector3 pos = swordSr.transform.localPosition;
                pos.x = -1.0f;
                swordSr.transform.localPosition = pos;
            }
            else if (!playerSr.flipX)
            {
                swordSr.flipX = false;
                swordSr.flipY = false;

                Vector3 pos = swordSr.transform.localPosition;
                pos.x = 1.0f;
                swordSr.transform.localPosition = pos;
            }
            playerAnim.Attack();
        }
    } 

    void Movement()
    {
        float moveH = Input.GetAxisRaw("Horizontal");

        if (moveH < 0)
            playerSr.flipX = true;
        else if (moveH > 0)
            playerSr.flipX = false;

        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
           
            StartCoroutine(ResetJumpRoutine());
            playerAnim.Jump(true);
        }

        rb.velocity = new Vector2(moveH * speed, rb.velocity.y);
        playerAnim.Move(moveH);
    }

    bool CheckGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 6);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);

        if (hitInfo.collider != null)
        {
            if (!resetJump)
            {
                playerAnim.Jump(false);
                return true;
            }
                
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
