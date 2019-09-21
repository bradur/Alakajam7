// Date   : 21.09.2019 23:23
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ProjectileShooterConfig ", menuName = "ScriptableObjects/New ProjectileShooterConfig")]
public class ProjectileShooterConfig : ScriptableObject
{

    [SerializeField]
    private Projectile prefab;
    public Projectile Prefab { get { return prefab; } }

    [SerializeField]
    private List<ProjectileConfig> projectileTiers;

    public ProjectileConfig GetProjectileConfig(int tier)
    {
        if (tier > -1 && projectileTiers.Count > tier)
        {
            return projectileTiers[tier];
        }
        return null;
    }

    public int MaxTier { get { return projectileTiers.Count - 1; } }

}