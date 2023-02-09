using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpSpeed;
    public string jumpSound;
    public Vector2 bottomPosition;
    public LayerMask collsionLayer;
    public float collisionRadius;
    public float coyoteTime;
    public float jumpBufferTime;

    private Rigidbody2D rb;
    private bool isStanding;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isStanding)
        {
            coyoteTimeCounter = coyoteTime;
        } else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        } else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            FindObjectOfType<AudioManager>().PlaySound(jumpSound);
            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }

    private void FixedUpdate()
    {
        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        isStanding = Physics2D.OverlapCircle(pos, collisionRadius, collsionLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        Gizmos.DrawWireSphere(pos, collisionRadius);
    }
}
