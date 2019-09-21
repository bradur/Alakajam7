// Date   : 21.09.2019 10:42
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CargoDropConfig ", menuName = "ScriptableObjects/New CargoDropConfig")]
public class CargoDropConfig : ScriptableObject
{

    [SerializeField]
    private float targetDetectionDistance = 18;
    public float TargetDetectionDistance { get { return targetDetectionDistance; } }

    [SerializeField]
    private float distanceForDropOffAfterTarget = 5;
    public float DistanceForDropOffAfterTarget { get { return distanceForDropOffAfterTarget; } }

    [SerializeField]
    private Cargo cargoPrefab;

    public Cargo CargoPrefab { get { return cargoPrefab; } }

}