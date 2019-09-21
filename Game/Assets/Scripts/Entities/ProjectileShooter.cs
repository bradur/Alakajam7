// Date   : 21.09.2019 17:42
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour
{

    [SerializeField]
    private Projectile projectilePrefab;

    private Projectile GetProjectile()
    {
        return Instantiate(projectilePrefab);
    }

    public void Shoot(Vector2 direction)
    {
        Projectile projectile = GetProjectile();
        projectile.transform.SetParent(transform);
        projectile.transform.position = transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
        projectile.Shoot(direction);
    }


}
