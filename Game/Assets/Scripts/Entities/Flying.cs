using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private FlightMovementConfig flightConfig;
    [SerializeField]
    private CargoDropConfig cargoConfig;

    private float lastFlap;

    private float origin;
    private bool flapFlag = true;
    private bool flyToDropOff = false;
    private bool dropOff = false;
    private Vector2 dropOffFlight;

    private GameObject dropOffTarget;

    [SerializeField]
    private Transform cargoPosition;

    private Cargo cargo;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        cargo = Instantiate(cargoConfig.CargoPrefab);
        cargo.Initialize();
        cargo.transform.SetParent(transform);
        cargo.transform.position = cargoPosition.position;
        lastFlap = Time.fixedTime;
        origin = transform.position.y;
        cargo.SetGravityOff();
    }

    void FixedUpdate()
    {
        if (dropOff)
        {
            body.velocity = dropOffFlight;
            if (cargo != null)
            {
                cargo.transform.parent = null;
                cargo.SetGravityOn();
            }
        }
        else if(flyToDropOff)
        {
            body.velocity = dropOffFlight;
            if (dropOffTarget.transform.position.x - transform.position.x > cargoConfig.DistanceForDropOffAfterTarget)
            {
                dropOff = true;
                flyToDropOff = false;
            }
        }
        else
        {
            if (flapFlag)
            {
                if (Time.fixedTime - lastFlap >= flightConfig.FlapInterval)
                {
                    body.velocity = new Vector2(body.velocity.x, flightConfig.FlapVelocity);
                    lastFlap = Time.fixedTime;
                }
                else
                {
                    body.velocity = new Vector2(body.velocity.x, flightConfig.FlapSpeedDampen * body.velocity.y);
                }
                body.velocity = new Vector2(-Time.fixedDeltaTime * flightConfig.Speed * 10, body.velocity.y);
            }
            else
            {
                body.velocity = new Vector2(-Time.fixedDeltaTime * flightConfig.Speed * 10, flightConfig.FallSpeed);
            }

            if (transform.position.y - origin > flightConfig.FlapUntil)
            {
                flapFlag = false;
            }
            else if (origin - transform.position.y > flightConfig.FlapUntil)
            {
                flapFlag = true;
            }

            if (transform.position.x - dropOffTarget.transform.position.x < cargoConfig.TargetDetectionDistance)
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

    public void ForceDrop()
    {
        body.velocity = dropOffFlight;
        if (cargo != null)
        {
            cargo.transform.parent = null;
            cargo.SetGravityOn();
        }
    }
}
