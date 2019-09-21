using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingSample : MonoBehaviour
{

    Climber climber;
    Rigidbody2D rb;

    Vector2 dir = Vector2.zero;
    bool jump;

    public float MoveSpeed = 20.0f;
    public float ClimbSpeed = 10.0f;
    public float JumpSpeed = 10.0f;

    private float jumpTimer = 0.0f;

    private int towerMask;


    // Start is called before the first frame update
    void Start()
    {
        climber = GetComponent<Climber>();
        rb = GetComponent<Rigidbody2D>();

        towerMask = LayerMask.GetMask("Tower");
    }
    
    // Update is called once per frame
    void Update()
    {
        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            jumpTimer = Time.time + 0.1f;
        }

        if (jumpTimer < Time.time)
        {
            jump = false;
        }

    }

    void FixedUpdate()
    {
        if (climber.Climbing)
        {
            if (dir.x > 0.1f)
            {
                climber.ClimbDown(ClimbSpeed);
            }
            if (dir.x < -0.1f)
            {
                climber.ClimbUp(ClimbSpeed);
            }
        }
        else
        {
            if (Mathf.Abs(dir.x) > 0.1f && HasRoom(dir.x))
            {
                rb.velocity = new Vector2(dir.x * MoveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        if (dir.y > 0.1f)
        {
            climber.ClimbUp(ClimbSpeed);
        }
        if (dir.y < -0.1f)
        {
            climber.ClimbDown(ClimbSpeed);
        }

        if (climber.Climbing && dir.magnitude < 0.1f)
        {
            rb.velocity = Vector2.zero;
        }

        if (jump)
        {
            if (climber.Climbing || IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, JumpSpeed));
                climber.Release();
                jump = false;
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(1.0f, 0.1f), 0.0f, Vector2.down, 0.2f, towerMask);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    private bool HasRoom(float direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast((Vector2)transform.position + Vector2.up * 0.5f, new Vector2(0.1f, 1.0f), 0.0f, new Vector2(direction, 0.0f), 0.5f, towerMask);
        if (hit.collider == null)
        {
            return true;
        }
        return false;
    }
}
