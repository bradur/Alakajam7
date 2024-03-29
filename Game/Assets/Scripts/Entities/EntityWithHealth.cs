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

    public bool LoseHealth(int amount) {
        if (health <= 0) {
            return false;
        }
        health -= amount;
        if (health < 0) {
            health = 0;
        }
        UpdateHealth(health);
        return health == 0;
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
        Flying flying = GetComponent<Flying>();
        if(flying != null)
        {
            flying.ForceDrop();
        }
        if (config.DeathEffect != null)
        {
            GameObject obj = Instantiate(config.DeathEffect);
            obj.transform.position = transform.position;
        }
        if (config.DestroyWhenHealthZero) {
            Destroy(gameObject);
        }
    }
}
