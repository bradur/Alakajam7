// Date   : 22.09.2019 09:53
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class UpdateManaEvent : UnityEvent<int>
{

}

public class InventoryManager : MonoBehaviour {

    public static InventoryManager main;

    [SerializeField]
    private InventoryConfig inventoryConfig;

    public UpdateManaEvent updateManaEvent;


    void Awake () {
        main = this;
    }

    void Start() {
        inventoryConfig.SetMana(inventoryConfig.StartingMana);
        updateManaEvent.Invoke(inventoryConfig.Mana);
    }

    public bool UseMana(int amount) {
        if (inventoryConfig.UseMana(amount)) {
            updateManaEvent.Invoke(inventoryConfig.Mana);
            return true;
        }
        return false;
    }

    public void GainMana(int amount) {
        inventoryConfig.GainMana(amount);
        updateManaEvent.Invoke(inventoryConfig.Mana);
    }
}
