// Date   : 21.09.2019 17:37
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private ProjectileConfig config;
    public void Instantiate(ProjectileConfig config) {
        this.config = config;
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
        Destroy(gameObject);
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
                //InventoryManager.main.GainMana(1);
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
    }
}
