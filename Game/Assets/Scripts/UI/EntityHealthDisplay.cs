// Date   : 21.09.2019 07:58
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EntityHealthDisplay : MonoBehaviour
{

    [SerializeField]
    private Text txtName;

    [SerializeField]
    private Image imgIcon;

    [SerializeField]
    private Text txtHealth;

    [SerializeField]
    private Image imgHealthBar;
    private RectTransform healthBatRectTransform;

    private int maxHealth;

    private float healthBarMaxWidth;

    [SerializeField]
    private EntityWithHealthConfig healthConfig;
    [SerializeField]
    private EntityHealthDisplayConfig displayConfig;


    private void InitializeIfNotInitialized()
    {
        if (healthBatRectTransform == null)
        {
            healthBatRectTransform = imgHealthBar.GetComponent<RectTransform>();
            healthBarMaxWidth = healthBatRectTransform.sizeDelta.x;
            maxHealth = healthConfig.Health;
            imgIcon.sprite = displayConfig.Icon;
        }
    }

    public void UpdateHealth(int health)
    {
        InitializeIfNotInitialized();
        if (health < 0)
        {
            health = 0;
        }
        float healthRatio = (float)health / maxHealth;
        healthBatRectTransform.sizeDelta = new Vector2(
            healthRatio * healthBarMaxWidth,
            healthBatRectTransform.sizeDelta.y
        );
        txtHealth.text = health.ToString();
    }

}
