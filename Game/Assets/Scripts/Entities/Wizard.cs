using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public GameObject MainHand;
    public GameObject OffHand;
    public Transform Target;

    private Vector2 lastPos;

    private float smoothSpeed;

    private float OFFHAND_SENSITIVITY = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aimMainHand();
        aimOffHand();
    }

    private void aimMainHand()
    {
        if (Target != null)
        {
            Vector2 targetPos = Target.position;
            Vector2 curPos = MainHand.transform.position;
            var targetDir = targetPos - curPos;

            var angleDiff = Vector3.SignedAngle(-MainHand.transform.right, targetDir, Vector3.forward);
            MainHand.transform.Rotate(Vector3.forward, angleDiff);
        }
    }

    private void aimOffHand()
    {
        var posDiff = lastPos - (Vector2)transform.position;
        var speed = posDiff.magnitude / Time.deltaTime;
        
        if (lastPos.x < transform.position.x)
        {
            speed = -speed;
        }

        if (speed < smoothSpeed)
        {
            smoothSpeed -= OFFHAND_SENSITIVITY * Time.deltaTime;
        }
        if (speed > smoothSpeed)
        {
            smoothSpeed += OFFHAND_SENSITIVITY * Time.deltaTime;
        }
        if (speed >= smoothSpeed - OFFHAND_SENSITIVITY * Time.deltaTime && speed <= smoothSpeed + OFFHAND_SENSITIVITY * Time.deltaTime)
        {
            smoothSpeed = speed;
        }

        Vector2 targetPos = (Vector2)transform.position + new Vector2(smoothSpeed, -10.0f);
        Vector2 curPos = OffHand.transform.position;
        var targetDir = targetPos - curPos;

        var angleDiff = Vector3.SignedAngle(-OffHand.transform.right, targetDir, Vector3.forward);
        OffHand.transform.Rotate(Vector3.forward, angleDiff);

        lastPos = transform.position;
    }
}
