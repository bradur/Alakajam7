// Date   : 21.09.2019 17:37
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private ProjectileConfig config;
    private float destroyTimer = -1.0f;

    private Rigidbody2D rb;
    private Collider2D collider;

    public ParticleSystem ps;

    public void Instantiate(ProjectileConfig config) {
        this.config = config;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        if (ps != null)
        {
            ps.Play();
        }
    }

    public void Shoot(Vector2 direction)
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(direction * config.Speed, ForceMode2D.Impulse);
        if (config.ShootSound) {
            // play
        }
    }

    public void Kill()
    {
        if (destroyTimer < 0)
        {
            if (config.HitEffect != null)
            {
                Instantiate(config.HitEffect, transform);
            }
            if (ps != null)
            {
                ps.Stop();
            }
            destroyTimer = Time.time + config.DestroyDelay;
            rb.gravityScale = 0;
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            collider.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (config.HitSound) {
            // play
        }

        EntityWithHealth e = collision2D.gameObject.GetComponent<EntityWithHealth>();
        if(e != null)
        {
            bool entityDied = e.LoseHealth(config.Damage);
            if (entityDied) {
                InventoryManager.main.GainMana(1);
            }
        }
        
        Kill();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > 200)
        {
            Kill();
        }

        if (destroyTimer > 0 && destroyTimer < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
