// Date   : 22.09.2019 17.57
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class AreaOfEffect : MonoBehaviour
{
    private float radius;
    private int damage;
    private int layerMaskValue;
    private Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, layerMaskValue);

        foreach (Collider2D collider in hits)
        {
            EntityWithHealth e = collider.gameObject.GetComponent<EntityWithHealth>();
            if (e != null)
            {
                bool entityDied = e.LoseHealth(damage);
                if (entityDied)
                {
                    if (e.gameObject.tag == "Badman")
                    {
                        InventoryManager.main.GainMana(4);
                    }
                    else
                    {
                        InventoryManager.main.GainMana(2);
                    }
                }
            }
        }
        Destroy(gameObject);
    }

    public Collider2D GetCollider()
    {
        return col;
    }

    public void SetStuff(float radius, int damage, int layerMask)
    {
        this.radius = radius;
        this.damage = damage;
        this.layerMaskValue = layerMask;
    }
}
