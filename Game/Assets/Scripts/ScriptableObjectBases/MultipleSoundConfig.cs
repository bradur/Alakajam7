// Date   : 22.09.2019 13.35
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MultipleSoundConfig ", menuName = "ScriptableObjects/New MultipleSoundConfig")]
public class MultipleSoundConfig : ScriptableObject
{

    [SerializeField]
    private List<AudioClip> sounds;
    public List<AudioClip> Sounds { get { return sounds; } }

    [SerializeField]
    private float chanceToPlay;
    public float ChanceToPlay { get { return chanceToPlay; } }

    [SerializeField]
    private float interval;
    public float Interval { get { return interval; } }


}