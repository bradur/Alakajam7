using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{

    private Stairs stairs;
    Rigidbody2D rb;

    public bool Climbing {
        get
        {
            return grabbed && IsReadyToClimb();
        }
    }

    private bool grabbed;
    private float gravityScale = 4.0f;
    private int layer;

    public LayerMask ClimbingLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        layer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (grabbed)
        {
            gameObject.layer = Tools.ToLayer(ClimbingLayer.value);
            rb.gravityScale = 0.0f;
        }
        else
        {
            gameObject.layer = layer;
            rb.gravityScale = gravityScale;
        }

        if (!IsReadyToClimb())
        {
            grabbed = false;
        }
    }

    public void ClimbUp(float speed)
    {
        if (stairs != null)
        {
            if (stairs.Top.y > transform.position.y + 0.1f)
            {
                grabbed = true;
                ClimbTowards(stairs.Top, speed);
            }
        }
    }

    public bool ClimbDown(float speed)
    {
        if (stairs != null)
        {
            if (stairs.Bottom.y < transform.position.y - 0.1f)
            {
                grabbed = true;
                ClimbTowards(stairs.Bottom, speed);
                return true;
            }
        }
        return false;
    }

    public void SetStairs(Stairs stairs)
    {
        this.stairs = stairs;
    }

    public void ClearFromStairs(Stairs stairs)
    {
        if (stairs == this.stairs)
        {
            this.stairs = null;
        }
    }

    public void Release()
    {
        grabbed = false;
    }

    private void ClimbTowards(Vector2 target, float speed)
    {

        Vector2 diff = target - (Vector2)transform.position;
        if (diff.magnitude > 0.1f)
        {
            var realTarget = target;

            if (stairs.Bottom.y > transform.position.y + 0.1f)
            {
                realTarget = stairs.Bottom;
            }
            else if (stairs.Top.y < transform.position.y - 0.2f)
            {
                realTarget = stairs.Top;
            }
            else
            {
                var stairsDir = stairs.Top - stairs.Bottom;

                Debug.DrawLine(stairs.Bottom, stairs.Bottom + stairsDir);
                var nearestStairsPoint = SmartestPointOnLine(stairs.Bottom, stairsDir, transform.position);
                Debug.DrawLine(transform.position, nearestStairsPoint);

                if (DistanceTo(nearestStairsPoint) > 0.1f)
                {
                    realTarget = nearestStairsPoint;
                }
            }

            Vector2 realDiff = realTarget - (Vector2)transform.position;

            Debug.DrawLine(transform.position, stairs.Bottom);
            Debug.DrawLine(transform.position, stairs.Top);

            realDiff.Normalize();
            rb.velocity = realDiff * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }

    private bool IsReadyToClimb()
    {
        if (stairs == null) return false;
        var diffTop = stairs.Top.y - transform.position.y;
        var diffBottom = transform.position.y - stairs.Bottom.y;
        return diffTop > 0.1f && diffBottom > 0.1f;
    }

    private float DistanceTo(Vector2 target)
    {
        return (target - (Vector2)transform.position).magnitude;
    }

    private static Vector2 NearestPointOnLine(Vector2 linePnt, Vector2 lineDir, Vector2 pnt)
    {
        lineDir.Normalize();
        var v = pnt - linePnt;
        var d = Vector3.Dot(v, lineDir);
        return linePnt + lineDir * d;
    }

    private static Vector2 SmartestPointOnLine(Vector2 linePnt, Vector2 lineDir, Vector2 pnt)
    {
        var x = linePnt.x + lineDir.x / lineDir.y * (pnt.y - linePnt.y);
        return new Vector2(x, pnt.y);
    }

}
