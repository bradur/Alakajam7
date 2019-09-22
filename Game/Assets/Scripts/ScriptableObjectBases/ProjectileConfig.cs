// Date   : 21.09.2019 17:32
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ProjectileConfig ", menuName = "ScriptableObjects/New ProjectileConfig")]
public class ProjectileConfig : ScriptableObject
{


    [SerializeField]
    private float speed = 1f;
    public float Speed { get { return speed; } }

    [SerializeField]
    private int damage = 1;
    public int Damage { get { return damage; } }

    [SerializeField]
    private int explosionRadius = 0;
    public int ExplosionRadius { get { return explosionRadius; } }

    [SerializeField]
    private float cooldown = 0.5f;

    public float Cooldown { get { return cooldown; } }

    [SerializeField]
    private AudioClip shootSound;
    public AudioClip ShootSound { get { return shootSound; } }

    [SerializeField]
    private AudioClip hitSound;
    public AudioClip HitSound { get { return hitSound; } }

    [SerializeField]
    private int cost;
    public int Cost { get { return cost; } }

    [SerializeField]
    private GameObject hitEffect;
    public GameObject HitEffect { get { return hitEffect; } }

    [SerializeField]
    private float destroyDelay = 1.0f;
    public float DestroyDelay { get { return destroyDelay; } }

    [SerializeField]
    private bool shouldBounce = true;
    public bool ShouldBounce { get { return shouldBounce; } }

    [SerializeField]
    private LayerMask hitLayerMask;
    public LayerMask HitLayerMask { get { return hitLayerMask; } }
}