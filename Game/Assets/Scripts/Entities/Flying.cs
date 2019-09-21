using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float flapTime = 0.1f;
    [SerializeField]
    private float flapSpeedDampen = 0.95f;
    [SerializeField]
    private float fallSpeed = -3f;
    [SerializeField]
    private Cargo cargo;
    [SerializeField]
    private float distanceForDropOffMode = 18;
    [SerializeField]
    private float distanceForDropOffAfterTarget = 3;

    private float lastFlap;
    private float flapVel = 5f;

    private float origin;
    private float flapUntil = 2;
    private bool flapFlag = true;
    private bool flyToDropOff = false;
    private bool dropOff = false;
    private Vector2 dropOffFlight;

    private GameObject dropOffTarget;

    // Start is called before the first frame update
    void Start()
    {
        lastFlap = Time.fixedTime;
        origin = transform.position.y;
        cargo.SetGravityOff();
    }

    void FixedUpdate()
    {
        if (dropOff)
        {
            body.velocity = dropOffFlight;
            cargo.transform.parent = null;
            cargo.SetGravityOn();
        }
        else if(flyToDropOff)
        {
            body.velocity = dropOffFlight;
            Debug.Log(dropOffTarget.transform.position.x - transform.position.x + ", " + distanceForDropOffAfterTarget);
            if (dropOffTarget.transform.position.x - transform.position.x > distanceForDropOffAfterTarget)
            {
                dropOff = true;
                flyToDropOff = false;
            }
        }
        else
        {
            if (flapFlag)
            {
                if (Time.fixedTime - lastFlap >= flapTime)
                {
                    body.velocity = new Vector2(body.velocity.x, flapVel);
                    lastFlap = Time.fixedTime;
                }
                else
                {
                    body.velocity = new Vector2(body.velocity.x, flapSpeedDampen * body.velocity.y);
                }
                body.velocity = new Vector2(-Time.fixedDeltaTime * speed * 10, body.velocity.y);
            }
            else
            {
                body.velocity = new Vector2(-Time.fixedDeltaTime * speed * 10, fallSpeed);
            }

            if (transform.position.y - origin > flapUntil)
            {
                flapFlag = false;
            }
            else if (origin - transform.position.y > flapUntil)
            {
                flapFlag = true;
            }

            if (transform.position.x - dropOffTarget.transform.position.x < distanceForDropOffMode)
            {
                flyToDropOff = true;
                float currentSpeed = body.velocity.magnitude;
                float distance = (transform.position - dropOffTarget.transform.position).magnitude;
                Vector2 direction = (dropOffTarget.transform.position - transform.position).normalized;
                dropOffFlight = direction * currentSpeed;
            }
        }
    }

    public void SetDropOffTarget(GameObject target)
    {
        dropOffTarget = target;
    }
}
