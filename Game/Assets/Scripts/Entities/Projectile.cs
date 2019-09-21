// Date   : 21.09.2019 17:37
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    private ProjectileConfig config;

    public void Shoot(Vector2 direction)
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(direction * config.Speed, ForceMode2D.Impulse);
        if (config.ShootSound) {
            // play
        }
    }

    void Update()
    {

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
        Kill();
    }
}
