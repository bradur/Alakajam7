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

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        if (config == null) {
            Debug.Log("<color=red>Entity Movement has no config!</color>");
        }
        else if (config.MovesInitially) {
            StartMoving();
        }
    }

    void Update()
    {
        if (shouldMove && canMove) {
            rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D) {
        int collisionLayer = collision2D.collider.gameObject.layer;
        if (Tools.IsInLayerMask(collisionLayer, config.StopAtLayer)) {
            StopMoving();
        }
        if (Tools.IsInLayerMask(collisionLayer, config.OnlyMovesOnLayer)) {
            canMove = true;
            StartMoving();
        }
    }

    void OnCollisionExit2D(Collision2D collision2D) {
        int collisionLayer = collision2D.collider.gameObject.layer;
        if (Tools.IsInLayerMask(collisionLayer, config.OnlyMovesOnLayer)) {
            canMove = false;
            StopMoving();
        }
    }

    public void StopMoving() {
        shouldMove = false;
        rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
    }

    public void StartMoving() {
        if (config.Direction == HorizontalDirection.Left) {
            velocityX = -config.Speed;
            shouldMove = true;
        } else if (config.Direction == HorizontalDirection.Right) {
            velocityX = config.Speed;
            shouldMove = true;
        } else {
            Debug.Log("No direction! Cannot move!");
        }
    }
}
