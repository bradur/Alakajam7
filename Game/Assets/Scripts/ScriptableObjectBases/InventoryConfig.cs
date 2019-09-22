// Date   : 22.09.2019 09:39
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "InventoryConfig ", menuName = "ScriptableObjects/New InventoryConfig")]
public class InventoryConfig : ScriptableObject
{

    /*[SerializeField]
    private int fireBallTier = 0;
    public int FireBallTier { get { return fireBallTier; } }

    [SerializeField]
    private int arcaneMissileTier = 0;
    public int ArcaneMissileTier { get { return arcaneMissileTier; } }*/

    [SerializeField]
    private int mana = 0;
    public int Mana { get { return mana; } }

    [SerializeField]
    private int startingMana = 0;
    public int StartingMana { get { return startingMana; } }

    public void SetMana(int amount) {
        mana = amount;
    }

    public bool UseMana(int amount) {
        if (amount <= mana) {
            mana -= amount;
            return true;
        }
        return false;
    }

    public void GainMana(int amount) {
        mana += amount;
    }
}