// Date   : 22.09.2019 18:23
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Cauldron : MonoBehaviour {

    [SerializeField]
    private GameObject toppled;
    [SerializeField]
    private GameObject intact;
    
    public void Topple() {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        intact.SetActive(false);
        toppled.SetActive(true);
        UIManager.main.GameOver();
    }
    public void UpdateHealth(int currentHealth)
    {
        if (currentHealth <= 0) {
            Topple();
        }
    }

}
