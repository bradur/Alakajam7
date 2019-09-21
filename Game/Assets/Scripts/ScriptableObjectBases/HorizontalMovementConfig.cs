// Date   : 20.09.2019 23:37
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum HorizontalDirection
{
    None,
    Left,
    Right
}

[CreateAssetMenu(fileName = "HorizontalMovementConfig", menuName = "ScriptableObjects/New HorizontalMovementConfig")]
public class HorizontalMovementConfig : ScriptableObject
{

    [SerializeField]
    private bool movesInitially = true;
    public bool MovesInitially { get { return movesInitially; } }

    [SerializeField]
    private LayerMask stopAtLayer;
    public LayerMask StopAtLayer { get { return stopAtLayer; } }

    [SerializeField]
    private LayerMask onlyMovesOnLayer;
    public LayerMask OnlyMovesOnLayer { get { return onlyMovesOnLayer; } }

    [SerializeField]
    [Range(1f, 10f)]
    private float speed = 1f;
    public float Speed { get { return speed; } }

    [SerializeField]
    private HorizontalDirection direction = HorizontalDirection.Left;
    public HorizontalDirection Direction { get { return direction; } }

    [SerializeField]
    private LayerMask flipDirectionWhenCollidingWith;
    public LayerMask FlipDirectionWhenCollidingWith { get { return flipDirectionWhenCollidingWith; } }

    [SerializeField]
    private bool climbDownStairs = false;
    public bool ClimbDownStairs { get { return climbDownStairs; } }

    [SerializeField]
    private float climbingSpeed = 10f;
    public float ClimbingSpeed { get { return climbingSpeed; } }


}