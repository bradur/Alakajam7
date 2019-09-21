using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsWaypoint : MonoBehaviour
{
    public Stairs Stairs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        var climber = other.GetComponent<Climber>();
        if (climber != null)
        {
            climber.SetStairs(Stairs);
        }
    }

    void OnTriggerExit(Collider other)
    {
        var climber = other.GetComponent<Climber>();
        if (climber != null)
        {
            climber.SetStairs(Stairs);
        }
    }
}
