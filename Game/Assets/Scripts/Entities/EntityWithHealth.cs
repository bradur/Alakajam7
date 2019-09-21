// Date   : 21.09.2019 07:47
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[System.Serializable]
public class UpdateHealthEvent : UnityEvent<int>
{

}

public class EntityWithHealth : MonoBehaviour
{

    [SerializeField]
    private EntityWithHealthConfig config;

    public UpdateHealthEvent updateHealthEvent;

    private int maxHealth;
    private int health;

    public int Health { get { return health; } }

    private void Start()
    {
        if (config != null)
        {
            maxHealth = config.Health;
            health = config.Health;
            UpdateHealth(health);
        }
        else
        {
            Debug.Log("<color=red>ENTITYWITHHEALTH DOESN'T HAVE HEALTH CONFIG!</color>");
        }
    }

    public void LoseHealth(int amount) {
        //Debug.Log("I am " + name + " and I'm losing " + amount + " health!");
        health -= amount;
        if (health < 0) {
            health = 0;
        }
        UpdateHealth(health);
    }

    public void AddHealth(int amount) {
        health += amount;
        if (health > maxHealth) {
            health = maxHealth;
        }
        UpdateHealth(health);
    }

    public void UpdateHealth(int currentHealth)
    {
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        if (updateHealthEvent == null)
        {
            updateHealthEvent = new UpdateHealthEvent();
        }
        updateHealthEvent.Invoke(currentHealth);

        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
