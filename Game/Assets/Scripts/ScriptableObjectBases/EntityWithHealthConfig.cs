// Date   : 21.09.2019 07:36
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "EntityWithHealthConfig ", menuName = "ScriptableObjects/New EntityWithHealthConfig")]
public class EntityWithHealthConfig : ScriptableObject
{

    [SerializeField]
    private int health = 1;
    public int Health { get { return health; } }

    [SerializeField]
    private bool destroyWhenHealthZero = true;
    public bool DestroyWhenHealthZero { get { return destroyWhenHealthZero; } }

    [SerializeField]
    private GameObject deathEffect;
    public GameObject DeathEffect { get { return deathEffect; } }

}