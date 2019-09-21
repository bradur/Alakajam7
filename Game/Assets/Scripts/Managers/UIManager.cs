// Date   : 21.09.2019 07:45
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public static UIManager main;
    [SerializeField]
    private GameObject waveWarning;

    private void Awake() {
        main = this;
    }

    void Update () {
    
    }

    public void ToggleWarning(bool show)
    {
        waveWarning.SetActive(show);
    }
    
}
