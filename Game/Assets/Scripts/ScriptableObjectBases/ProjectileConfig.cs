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
    private AudioClip shootSound;
    public AudioClip ShootSound { get { return shootSound; } }

    [SerializeField]
    private AudioClip hitSound;
    public AudioClip HitSound { get { return hitSound; } }
}