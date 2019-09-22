// Date   : 22.09.2019 17.57
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class AreaOfEffect : MonoBehaviour
{
    [SerializeField]
    private ProjectileConfig config;
    private Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, config.ExplosionRadius, config.HitLayerMask.value);

        foreach (Collider2D collider in hits)
        {
            EntityWithHealth e = collider.gameObject.GetComponent<EntityWithHealth>();
            if (e != null)
            {
                bool entityDied = e.LoseHealth(config.Damage);
                if (entityDied)
                {
                    InventoryManager.main.GainMana(1);
                }
            }
        }
        Destroy(gameObject);
    }

    public Collider2D GetCollider()
    {
        return col;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EntityWithHealth e = collision.gameObject.GetComponent<EntityWithHealth>();
        if (e != null)
        {
            bool entityDied = e.LoseHealth(config.Damage);
            if (entityDied)
            {
                InventoryManager.main.GainMana(1);
            }
        }

        Destroy(gameObject);
    }
}