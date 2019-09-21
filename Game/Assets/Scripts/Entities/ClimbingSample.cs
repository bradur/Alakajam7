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


    // Start is called before the first frame update
    void Start()
    {
        climber = GetComponent<Climber>();
        rb = GetComponent<Rigidbody2D>();
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
            if (Mathf.Abs(dir.x) > 0.1f)
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

        if (jump)
        {
            if (climber.Climbing || IsGrounded())
            {
                Debug.Log("JUMP!");
                rb.AddForce(new Vector2(0, JumpSpeed));
                climber.Release();
                jump = false;
            }
        }
    }

    private bool IsGrounded()
    {
        return true;
    }
}
