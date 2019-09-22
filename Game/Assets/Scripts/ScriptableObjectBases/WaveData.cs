// Date   : 21.09.2019 17.15
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "WaveData ", menuName = "ScriptableObjects/New WaveData")]
public class WaveData : ScriptableObject
{
    [SerializeField]
    private float duration;
    public float Duration { get { return duration; } }

    [SerializeField]
    private List<Group> groups;
    public List<Group> Groups { get { return groups; } }

}

[Serializable]
public class Enemy
{
    public EnemyType type;
    public SpawnPoint spawn;
}

[Serializable]
public class Group
{
    public float startDelay; //time before the group starts spawning
    public float interval; //interval between spawning enemies inside this group
    public List<Enemy> enemies;
}

public enum EnemyType
{
    Walking,
    Flying,
    Shield
}

public enum SpawnPoint
{
    Ground,
    Mid,
    High
}