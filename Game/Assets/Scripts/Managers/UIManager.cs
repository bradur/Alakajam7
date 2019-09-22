// Date   : 21.09.2019 07:45
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public static UIManager main;
    [SerializeField]
    private GameObject waveWarning;

    private Animator animator;

    private void Awake() {
        main = this;
    }

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update () {
    
    }

    public void ToggleWarning(bool show)
    {
        waveWarning.SetActive(show);
    }

    public void ShowShop() {
        Debug.Log("Show!");
        animator.SetTrigger("showShop");
    }

    public void HideShop() {
        Debug.Log("Hide!!");
        animator.SetTrigger("hideShop");
    }
    
}
