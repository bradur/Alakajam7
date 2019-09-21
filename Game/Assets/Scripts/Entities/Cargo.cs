using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Initialize() {
        body = GetComponent<Rigidbody2D>();
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
