// Date   : 22.09.2019 12:06
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellTierDisplay : MonoBehaviour {

    [SerializeField]
    private Text txtTier;
    public void UpdateTier(int tier) {
        txtTier.text = (tier + 1).ToString();
    }

}
