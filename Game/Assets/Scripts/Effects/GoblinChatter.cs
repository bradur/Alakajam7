// Date   : 22.09.2019 14.00
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class GoblinChatter : MonoBehaviour {
    [SerializeField]
    private MultipleSoundConfig soundConfig;
    private AudioSource chatterSource;

    private float lastSoundTime;

    void Start () {
        chatterSource = GetComponent<AudioSource>();
        lastSoundTime = Time.fixedTime;
    }

    void FixedUpdate () {
        if(Time.fixedTime - lastSoundTime > soundConfig.Interval)
        {
            if(Random.Range(0, 1) <= soundConfig.ChanceToPlay)
            {
                AudioClip randomSound = soundConfig.Sounds[Mathf.RoundToInt(Random.Range(0, soundConfig.Sounds.Count - 1))];
                chatterSource.PlayOneShot(randomSound);
                Debug.Log("moi");
            }
            lastSoundTime = Time.fixedTime;
        }
    }
}
