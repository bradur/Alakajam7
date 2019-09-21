using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTestManager : MonoBehaviour
{
    [SerializeField]
    private Flying flyingPrefab;
    [SerializeField]
    private FlightPath highPath;
    [SerializeField]
    private FlightPath lowPath;
    [SerializeField]
    private GameObject dropOffTarget;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FlightPath parent = lowPath;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                parent = highPath;
            }

            Flying f = Instantiate(flyingPrefab, parent.getSpawner().transform, true);
            f.transform.localPosition = Vector3.zero;
            f.SetDropOffTarget(dropOffTarget);
        }
    }
}
