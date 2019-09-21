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

    private int health;

    public int Health { get { return health; } }

    private void Start()
    {
        if (config != null)
        {
            health = config.Health;
            UpdateHealth(health);
        }
        else
        {
            Debug.Log("<color=red>ENTITYWITHHEALTH DOESN'T HAVE HEALTH CONFIG!</color>");
        }
    }

    public void LoseHealth(int amount) {
        Debug.Log("I am " + name + " and I'm losing " + amount + " health!");
        health -= amount;
        UpdateHealth(health);
    }

    public void UpdateHealth(int currentHealth)
    {
        if (updateHealthEvent == null)
        {
            updateHealthEvent = new UpdateHealthEvent();
        }
        updateHealthEvent.Invoke(currentHealth);
    }
}
