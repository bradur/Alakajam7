using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEntityMovement : MonoBehaviour
{
    [SerializeField]
    private HorizontalMovementConfig config;

    private Rigidbody2D rigidbody2D;
    private float velocityX;

    private bool shouldMove = false;
    private bool canMove = false;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
            rigidbody2D.velocity = new Vector2(velocityX, rigidbody2D.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D) {
        int collisionLayer = collision2D.collider.gameObject.layer;
        if (Tools.IsInLayerMask(collisionLayer, config.StopAtLayer)) {
            StopMoving();
        }
        if (Tools.IsInLayerMask(collisionLayer, config.OnlyMovesOnLayer)) {
            canMove = true;
            Debug.Log("Hit ground!");
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
        Debug.Log("Stopped moving!");
        shouldMove = false;
        rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
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
