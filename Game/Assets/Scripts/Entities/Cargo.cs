using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{

    private Rigidbody2D body;
    private CapsuleCollider2D capsuleCollider2D;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Initialize()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        animator.SetTrigger("Fly");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGravityOn()
    {
        body.gravityScale = 1;
        body.isKinematic = false;
        capsuleCollider2D.enabled = true;
    }

    public void SetGravityOff()
    {
        body.gravityScale = 0;
        body.isKinematic = true;
        capsuleCollider2D.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Tower") || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetTrigger("Walk");
        }
    }
}
