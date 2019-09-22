// Date   : 22.09.2019 19.46
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "WaveCount", menuName = "ScriptableObjects/New WaveCount")]
public class WaveCount : ScriptableObject
{
    [SerializeField]
    private float count;
    public float Count { get { return count; } set { count = value; } }

}