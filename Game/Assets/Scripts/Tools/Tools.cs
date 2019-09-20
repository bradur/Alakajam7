// Date   : 21.09.2019 00:13
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour
{

    public static bool IsInLayerMask(int layer, LayerMask layermask)
    {
        return layermask == (layermask | (1 << layer));
    }
}
