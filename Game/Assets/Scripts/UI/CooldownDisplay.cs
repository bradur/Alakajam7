// Date   : 21.09.2019 23:48
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CooldownDisplay : MonoBehaviour {

    [SerializeField]
    private Image imgRadialCooldown;

    public void UpdateCooldownPercentage(float percentage) {
        if (!imgRadialCooldown.enabled) {
            imgRadialCooldown.enabled = true;
        }
        imgRadialCooldown.fillAmount = percentage * 1f;
        if (percentage == 0f) {
            imgRadialCooldown.fillAmount = 1f;
            imgRadialCooldown.enabled = false;
        }
    }

}
