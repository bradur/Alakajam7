// Date   : 22.09.2019 09:44
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveCounter : MonoBehaviour
{

    [SerializeField]
    private Text txtWaveTimeCount;
    [SerializeField]
    private WaveCount waveCount;


    private void Start()
    {
    }

    void Update()
    {
        txtWaveTimeCount.text = (waveCount.Count + 1).ToString();
    }

}
