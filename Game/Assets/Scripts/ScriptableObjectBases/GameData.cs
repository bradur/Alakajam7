// Date   : 21.09.2019 16.28
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "GameData ", menuName = "ScriptableObjects/New GameData")]
public class GameData : ScriptableObject
{

    [SerializeField]
    private List<WaveData> waves;
    public List<WaveData> Waves { get { return waves; } }

} 