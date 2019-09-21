// Date   : 21.09.2019 10:42
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "FlightMovementConfig ", menuName = "ScriptableObjects/New FlightMovementConfig")]
public class FlightMovementConfig : ScriptableObject
{

    [SerializeField]
    private float speed = 35f;
    public float Speed { get { return speed; } }

    [SerializeField]
    private float flapInterval = 0.66f;
    public float FlapInterval { get { return flapInterval; } }

    [SerializeField]
    private float flapSpeedDampen = 0.95f;
    public float FlapSpeedDampen { get { return flapSpeedDampen; } }

    [SerializeField]
    private float fallSpeed = -3;
    public float FallSpeed { get { return fallSpeed; } }

    [SerializeField]
    private float flapVelocity = 5f;
    public float FlapVelocity { get { return flapVelocity; } }
    [SerializeField]
    private float flapUntil = 2f;

    public float FlapUntil { get { return flapUntil; } }

}