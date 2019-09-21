// Date   : 21.09.2019 09:47
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class DealDamageOverTimeOnContact : MonoBehaviour
{

    [SerializeField]
    private DealDamageOverTimeConfig config;

    private bool isInContact = false;

    private EntityWithHealth target;

    private float damageInterval = 0f;
    private float damageTimer = 0f;

    private bool hasDealtInitialDamage = false;

    void Update() {
        if (isInContact && target != null) {
            damageTimer += Time.deltaTime;
            if (damageTimer > damageInterval) {
                DealDamage();
                damageTimer = 0f;
            }
        }
    }

    private void StartDealingDamage (EntityWithHealth targetEntity) {
        target = targetEntity;
        ResetDamageInterval();
        damageTimer = 0f;
    }

    private void ResetDamageInterval() {
        if (!hasDealtInitialDamage && config.InitialIntervalIsZero) {
            damageInterval = 0f;
        } else {
            damageInterval = config.DamageDealInterval;
        }
    }

    private void DealDamage() {
        target.LoseHealth(config.GetRandomDamage());
        if (!hasDealtInitialDamage) {
            hasDealtInitialDamage = true;
        }
        ResetDamageInterval();
    }

    private void StopDealingDamage () {
        target = null;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        int collisionLayer = collision2D.gameObject.layer;
        if (Tools.IsInLayerMask(collisionLayer, config.TargetLayers)) {
            EntityWithHealth targetEntity = collision2D.gameObject.GetComponent<EntityWithHealth>();
            if (targetEntity != null) {
                isInContact = true;
                StartDealingDamage(targetEntity);
                Debug.Log("<color=green>In contact with " + collision2D.gameObject.name + "</color>");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        EntityWithHealth targetEntity = collision2D.gameObject.GetComponent<EntityWithHealth>();
        if (targetEntity != null && targetEntity == target) {
            Debug.Log("<color=yellow>Losing contact with " + collision2D.gameObject.name + "!</color>");
            isInContact = false;
            target = null;
        }
    }
}
