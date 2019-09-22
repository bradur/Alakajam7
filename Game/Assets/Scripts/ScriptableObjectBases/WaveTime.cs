// Date   : 22.09.2019 19.46
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "WaveTime ", menuName = "ScriptableObjects/New WaveTime")]
public class WaveTime : ScriptableObject
{
    [SerializeField]
    private float waveMaxTime;
    public float WaveMaxTime { get { return waveMaxTime; } set { waveMaxTime = value; } }

    [SerializeField]
    private float waveStartTime;
    public float WaveStartTime { get { return waveStartTime; } set { waveStartTime = value; } }

}