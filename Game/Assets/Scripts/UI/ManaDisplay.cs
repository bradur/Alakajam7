// Date   : 22.09.2019 09:44
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaDisplay : MonoBehaviour {

    [SerializeField]
    private Text txtManaCount;

    private Animator animator;

    private int currentMana = -1;

    private void Start () {
        animator = GetComponent<Animator>();
    }

    public void UpdateMana (int mana) {
        bool firstTime = currentMana == -1;
        if (!firstTime) {
            if (currentMana > mana) {
                animator.SetTrigger("LoseMana");
            } else if (mana > currentMana) {
                animator.SetTrigger("GainMana");
            }
        }
        currentMana = mana;
        txtManaCount.text = mana.ToString();
    }

}
