// Date   : 21.09.2019 18:02
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class PlayerAimShoot : MonoBehaviour {

    [SerializeField]
    private CrossHairAimer aimer;

    [SerializeField]
    private ProjectileShooter fireballShooter;

    [SerializeField]
    private ProjectileShooter arcaneMissileShooter;

    void Start () {
        if (aimer == null) {
            Debug.Log("<color=red>CrossHairAimer not defined for " + name + "!</color>");
        }
        if (fireballShooter == null) {
            Debug.Log("<color=red>FireballShooter not defined for " + name + "!</color>");
        }
        if (arcaneMissileShooter == null) {
            Debug.Log("<color=red>ArcaneMissileShooter not defined for " + name + "!</color>");
        }
    }

    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            fireballShooter.Shoot(aimer.GetDirection());
        }
        if (Input.GetMouseButtonDown(1)) {
            arcaneMissileShooter.Shoot(aimer.GetDirection());
        }
    }
}
