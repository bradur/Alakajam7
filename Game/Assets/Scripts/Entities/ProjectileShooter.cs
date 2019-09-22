// Date   : 21.09.2019 17:42
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class UpdateCooldownPercentageEvent : UnityEvent<float>
{

}
[System.Serializable]
public class UpdateSpellTier : UnityEvent<int>
{

}



public class ProjectileShooter : MonoBehaviour
{

    [SerializeField]
    private ProjectileShooterConfig config;

    [SerializeField]
    public UpdateCooldownPercentageEvent updateCooldownPercentageEvent;

    [SerializeField]
    private Transform projectileContainer;

    private ProjectileConfig projectileConfig;
    private int tier = 0;
    private int maxTier;

    private float cooldownTimer = 0f;
    public UpdateSpellTier updateSpellTier;

    public void UpdateSpellTier(int tier) {
        updateSpellTier.Invoke(tier);
    }

    private void Start() {
        maxTier = config.MaxTier;
        projectileConfig = config.GetProjectileConfig(tier);
        updateSpellTier.Invoke(tier);
    }

    private Projectile GetProjectile()
    {
        return Instantiate(config.Prefab);
    }

    public void IncreaseTier() {
        tier += 1;
        if (tier > maxTier) {
            tier = maxTier;
        }
        updateSpellTier.Invoke(tier);
    }

    public void Shoot(Vector2 direction)
    {
        if (cooldownTimer > 0f) {
            return;
        }
        Projectile projectile = GetProjectile();
        projectileConfig = config.GetProjectileConfig(tier);
        projectile.Instantiate(projectileConfig);

        if(projectileContainer != null)
        {
            projectile.transform.SetParent(projectileContainer);
        }

        projectile.transform.position = transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
        projectile.Shoot(direction);
        UpdateCooldown(projectileConfig.Cooldown);
    }

    public void UpdateCooldown(float currentCooldown)
    {
        cooldownTimer = currentCooldown;
        if (cooldownTimer < 0f) {
            cooldownTimer = 0f;
        }
        if (updateCooldownPercentageEvent != null) {
            updateCooldownPercentageEvent.Invoke(cooldownTimer / projectileConfig.Cooldown);
        }
    }

    public bool KeyIsPressed() {
        return config.KeyIsPressed();
    }

    void Update() {
        cooldownTimer -= Time.deltaTime;
        UpdateCooldown(cooldownTimer);
    }

}
