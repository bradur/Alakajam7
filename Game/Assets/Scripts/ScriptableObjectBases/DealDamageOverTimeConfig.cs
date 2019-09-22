// Date   : 21.09.2019 09:48
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DealDamageOverTimeConfig ", menuName = "ScriptableObjects/New DealDamageOverTimeConfig")]
public class DealDamageOverTimeConfig : ScriptableObject
{

    [SerializeField]
    private LayerMask targetLayers;
    public LayerMask TargetLayers { get { return targetLayers; } }

    [SerializeField]
    private float damageDealInterval = 2f;
    public float DamageDealInterval { get { return damageDealInterval; } }

    [SerializeField]
    private int damageMin = 1;

    [SerializeField]
    private int damageMax = 5;

    [SerializeField]
    private bool initialIntervalIsZero = true;
    public bool InitialIntervalIsZero { get { return initialIntervalIsZero; } }

    public int GetRandomDamage()
    {
        return Random.Range(damageMin, damageMax);
    }
}