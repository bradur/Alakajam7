// Date   : 21.09.2019 18:58
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    private BoxCollider2D boxCollider2D;
    private EntityWithHealth entityHealth;

    private void Start( ) {
        boxCollider2D = GetComponent<BoxCollider2D>();
        entityHealth = GetComponent<EntityWithHealth>();
    }

    private void BreakDown() {
        // play sound, show animation
        DisableCollider();
    }

    public void Repair(int amount) {
        entityHealth.AddHealth(amount);
        if (amount > 0 && boxCollider2D.enabled == false) {
            EnableCollider();
        }
    }

    public void UpdateHealth(int health) {
        if (health < 1) {
            BreakDown();
        }
    }

    private void DisableCollider() {
        boxCollider2D.enabled = false;
    }


    private void EnableCollider() {
        boxCollider2D.enabled = false;
    }
}
