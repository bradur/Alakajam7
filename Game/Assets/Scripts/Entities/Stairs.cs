using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField]
    private Transform top, bottom;

    public Vector2 Top { get; private set; }
    public Vector2 Bottom { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Top = top.position;
        Bottom = bottom.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var climber = other.GetComponent<Climber>();
        if (climber != null)
        {
            climber.SetStairs(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var climber = other.GetComponent<Climber>();
        if (climber != null)
        {
            climber.ClearFromStairs(this);
        }
    }
}
