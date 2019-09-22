// Date   : 22.09.2019 10:52
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RepairButtonDisplay : MonoBehaviour {

    private Button button;

    [SerializeField]
    private Color disabledColor = Color.red;
    [SerializeField]
    private Text txtCost;
    private Color originalColor = new Color(0, 0, 0, 0);
    [SerializeField]
    private Image indicatorImage;
    [SerializeField]
    private int cost = 1;

    private int maxHealth = -1;
    private int currentHealth;

    private int currentMana;

    private void Start() {
        button = GetComponent<Button>();
        //originalColor = indicatorImage.color;
        txtCost.text = cost.ToString();
    }

    public void UpdateMana(int mana) {
        currentMana = mana;
        if (mana < cost) {
            DisableButton();
        } else if (currentHealth != maxHealth) {
            EnableButton();
        }
    }

    private void DisableButton() {
        button = GetComponent<Button>();
        button.enabled = false;
        indicatorImage.color = disabledColor;
    }

    private void EnableButton() {
        button = GetComponent<Button>();
        button.enabled = true;
        indicatorImage.color = originalColor;
    }

    public void UpdateDoorHealth(int health) {
        currentHealth = health;
        if (maxHealth == -1) {
            maxHealth = health;
        }
        if (health == maxHealth) {
            DisableButton();
        } else if (currentMana >= cost){
            EnableButton();
        }
    }

}
