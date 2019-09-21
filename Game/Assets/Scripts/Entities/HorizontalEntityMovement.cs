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
    private bool canMove = false;

    private HorizontalDirection currentDirection;

    private Climber climber;

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

    void FixedUpdate()
    {
        /*if (shouldMove && canMove)
        {
            rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
        }*/
        if (config.ClimbDownStairs)
        {
            if (climber != null)
            {
                if (climber.ClimbDown(config.ClimbingSpeed)) {
                    shouldMove = false;
                } else {
                    shouldMove = true;
                }
            }
            else
            {
                Debug.Log("<color=red>No climber on " + gameObject.name + "!</color>");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        int collisionLayer = collision2D.collider.gameObject.layer;
        if (Tools.IsInLayerMask(collisionLayer, config.StopAtLayer))
        {
            StopMoving();
        }
        if (Tools.IsInLayerMask(collisionLayer, config.OnlyMovesOnLayer))
        {
            canMove = true;
            StartMoving();
        }
        if (Tools.IsInLayerMask(collisionLayer, config.FlipDirectionWhenCollidingWith))
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

    void OnCollisionExit2D(Collision2D collision2D)
    {
        int collisionLayer = collision2D.collider.gameObject.layer;
        if (Tools.IsInLayerMask(collisionLayer, config.OnlyMovesOnLayer))
        {
            canMove = false;
            StopMoving();
        }
    }

    public void StopMoving()
    {
        shouldMove = false;
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
            Debug.Log("No direction! Cannot move!");
        }
        if (shouldMove && canMove) {
            rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
            Debug.Log("Starting movement!");
        }
    }
}
