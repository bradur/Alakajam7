using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGravityOn()
    {
        body.gravityScale = 1;
        body.isKinematic = false;
    }

    public void SetGravityOff()
    {
        body.gravityScale = 0;
        body.isKinematic = true;
    }
}
