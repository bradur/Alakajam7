// Date   : 22.09.2019 12:38
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TierUpgradeButton : MonoBehaviour {

    [SerializeField]
    private Text txtCost;

    private Button button;
    [SerializeField]
    private Image indicatorImage;
    
    private Color originalColor;
    [SerializeField]
    private Color disabledColor = Color.red;

    private bool maxTierReached = false;

    private int cost;

    private int currentMana;

    [SerializeField]
    private ProjectileShooter shooter;

    private void Start() {
        button = GetComponent<Button>();
        originalColor = indicatorImage.color;
    }

    public void UpdateTier(int tier) {
        tier += 1;
        ProjectileConfig config = shooter.Config.GetProjectileConfig(tier);
        if (config == null) {
            txtCost.text = "-";
            maxTierReached = true;
            DisableButton();
        } else {
            cost = config.Cost;
            txtCost.text = cost.ToString();
            if (cost > currentMana) {
                DisableButton();
            }
        }
    }

    public void UpdateMana(int mana) {
        currentMana = mana;
        if (mana < cost) {
            DisableButton();
        }
        if (mana >= cost)
        {
            button = GetComponent<Button>();
            if (button.enabled == false && !maxTierReached) {
                EnableButton();
            }
        }
    }

    private void DisableButton() {
        button.enabled = false;
        indicatorImage.color = disabledColor;
    }

    private void EnableButton() {
        button.enabled = true;
        indicatorImage.color = originalColor;
    }

    public void IncreaseTier() {
        if (InventoryManager.main.UseMana(cost)) {
            shooter.IncreaseTier();
        }
    }

}
