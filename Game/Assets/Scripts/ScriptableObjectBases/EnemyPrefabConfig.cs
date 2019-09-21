// Date   : 21.09.2019 17.31
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "EnemyPrefabConfig ", menuName = "ScriptableObjects/New EnemyPrefabConfig")]
public class EnemyPrefabConfig : ScriptableObject
{

    [SerializeField]
    private List<EnemyPrefabMapping> enemyPrefabs;
    public List<EnemyPrefabMapping> EnemyPrefabs { get { return enemyPrefabs; } }

}

[Serializable]
public class EnemyPrefabMapping
{
    public EnemyType type;
    public GameObject prefab;
}