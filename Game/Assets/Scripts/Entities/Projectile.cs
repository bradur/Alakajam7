// Date   : 21.09.2019 17:37
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private AreaOfEffect areaOfEffect;
    private ProjectileConfig config;
    private AudioSource audioSource;
    private float destroyTimer = -1.0f;

    private Rigidbody2D rb;
    private Collider2D collider;

    public ParticleSystem ps;

    private int BOUNCE_LAYER;
    private float collisionTimer = 0.0f;
    private Vector2 velocityBeforeCollision;

    private bool firstHit;

    public void Instantiate(ProjectileConfig config) {
        this.config = config;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        this.config = config;
        audioSource = GetComponent<AudioSource>();
        if (ps != null)
        {
            ps.Play();
        }
        BOUNCE_LAYER = LayerMask.NameToLayer("MagicBounce");
    }

    public void Shoot(Vector2 direction)
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(direction * config.Speed, ForceMode2D.Impulse);
        if (audioSource != null && config.ShootSound != null) {
            audioSource.PlayOneShot(config.ShootSound);
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

            if(areaOfEffect != null)
            {
                areaOfEffect.transform.parent = null;
                areaOfEffect.SetStuff(config.ExplosionRadius, config.Damage, config.HitLayerMask.value);
                areaOfEffect.gameObject.SetActive(true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (config.HitSound != null)
        {
            AudioSource.PlayClipAtPoint(config.HitSound, Camera.main.transform.position);
        }

        if (config.ShouldBounce && collision2D.gameObject.layer == BOUNCE_LAYER)
        {
            if (velocityBeforeCollision.normalized.y < -0.2f)
            {
                rb.velocity = new Vector2(velocityBeforeCollision.x, -velocityBeforeCollision.y);
            }
            else
            {
                var velocity = new Vector2(-5 + Random.value * 10, 10 + Random.value * 5);
                rb.velocity = velocity.normalized * velocityBeforeCollision.magnitude;
            }
            collider.enabled = false;
            collisionTimer = Time.time + 0.2f;
            return;
        }

        EntityWithHealth e = collision2D.gameObject.GetComponent<EntityWithHealth>();
        if(firstHit && e != null)
        {
            firstHit = false;
            bool entityDied = e.LoseHealth(config.Damage);
            if (entityDied)
            {
                if (e.gameObject.tag == "Badman")
                {
                    InventoryManager.main.GainMana(3);
                }
                else
                {
                    InventoryManager.main.GainMana(1);
                }
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

        if (destroyTimer < 0 && collisionTimer < Time.time && !collider.enabled)
        {
            collider.enabled = true;
        }
        velocityBeforeCollision = rb.velocity;
    }

    void FixedUpdate()
    {
        firstHit = true;
    }
}
