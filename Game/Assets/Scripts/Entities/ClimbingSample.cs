using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingSample : MonoBehaviour
{

    Climber climber;
    Rigidbody2D rb;

    Vector2 dir = Vector2.zero;

    float speed = 10.0f;

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
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(dir.x) > 0.001 && !climber.Climbing)
        {
            rb.velocity = new Vector2(dir.x * speed, 0f);
        }


        if (dir.y > 0.001)
        {
            climber.ClimbUp(speed);
        }
        if (dir.y < -0.001)
        {
            climber.ClimbDown(speed);
        }

        if (dir.magnitude < 0.1f)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
