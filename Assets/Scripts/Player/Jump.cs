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

    private Rigidbody2D rb;
    private bool isStanding;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isStanding)
        {
            Debug.Log("Jump pressed.");
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
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
