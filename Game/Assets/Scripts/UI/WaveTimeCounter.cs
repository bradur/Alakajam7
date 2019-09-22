// Date   : 22.09.2019 09:44
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveTimeCounter : MonoBehaviour {

    [SerializeField]
    private Text txtWaveTimeCount;
    [SerializeField]
    private WaveTime waveTime;


    private void Start () {
    }

    void Update () {
        float seconds = Time.time - waveTime.WaveStartTime;
        float secondsLeft = waveTime.WaveMaxTime - seconds;
        txtWaveTimeCount.text = (Mathf.RoundToInt(secondsLeft)).ToString();
    }

}
