using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEntityMovement : MonoBehaviour
{
    [SerializeField]
    private HorizontalMovementConfig config;

    private Rigidbody2D rb2D;
    private float velocityX;

    private bool shouldMove = false;
    private bool stopped = false;

    private HorizontalDirection currentDirection;

    private Climber climber;

    private bool grounded = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        if (config == null)
        {
            Debug.Log("<color=red>Entity Movement has no config!</color>");
        }
        else
        {
            currentDirection = config.Direction;
            if (config.ClimbDownStairs)
            {
                climber = GetComponent<Climber>();
            }
            if (config.MovesInitially)
            {
                StartMoving();
            }
        }
    }

    void Update()
    {
        bool wasGrounded = grounded;
        grounded = Physics2D.Linecast(
            transform.position,
            new Vector2(transform.position.x, transform.position.y - 0.1f),
            config.OnlyMovesOnLayer
        );
        Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - 0.1f), Color.red);
        if (!wasGrounded && grounded)
        {
            StartMoving();
        }
        else if (wasGrounded && !grounded)
        {
            StopMoving();
        }
    }

    void FixedUpdate()
    {
        if (config.ClimbDownStairs)
        {
            if (climber != null)
            {
                if (climber.ClimbDown(config.ClimbingSpeed))
                {
                    shouldMove = false;
                }
                else
                {
                    shouldMove = true;
                }
            }
            else
            {
                Debug.Log("<color=red>No climber on " + gameObject.name + "!</color>");
            }
        }
    }

    void ReactToCollisionOrTriggerEnter(GameObject collisionGameObject)
    {

        if (Tools.IsInLayerMask(collisionGameObject.layer, config.StopAtLayer))
        {
            stopped = true;
            StopMoving();
        }
        if (Tools.IsInLayerMask(collisionGameObject.layer, config.FlipDirectionWhenCollidingWith))
        {

            if (currentDirection == HorizontalDirection.Left)
            {
                currentDirection = HorizontalDirection.Right;
            }
            else if (currentDirection == HorizontalDirection.Right)
            {
                currentDirection = HorizontalDirection.Left;
            }
            StartMoving();
        }
    }

    void ReactToCollisionOrTriggerExit(GameObject collisionGameObject)
    {
        if (Tools.IsInLayerMask(collisionGameObject.layer, config.StopAtLayer))
        {
            stopped = false;
            StartMoving();
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        ReactToCollisionOrTriggerEnter(collider2D.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        ReactToCollisionOrTriggerEnter(collision2D.collider.gameObject);
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        ReactToCollisionOrTriggerExit(collider2D.gameObject);
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        ReactToCollisionOrTriggerExit(collision2D.collider.gameObject);
    }

    public void StopMoving()
    {
        rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
    }

    public void StartMoving()
    {
        if (currentDirection == HorizontalDirection.Left)
        {
            velocityX = -config.Speed;
            shouldMove = true;
        }
        else if (currentDirection == HorizontalDirection.Right)
        {
            velocityX = config.Speed;
            shouldMove = true;
        }
        else
        {
            //Debug.Log("No direction! Cannot move!");
            return;
        }
        Debug.Log("ShouldMove:" + shouldMove + " Grounded: " + grounded + " Stopped: " + stopped);
        if (shouldMove && grounded && !stopped)
        {
            rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
        }
    }
}
