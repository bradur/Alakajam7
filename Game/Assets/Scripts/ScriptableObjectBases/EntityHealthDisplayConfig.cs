// Date   : 21.09.2019 07:59
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EntityHealthDisplayConfig ", menuName = "ScriptableObjects/New EntityHealthDisplayConfig")]
public class EntityHealthDisplayConfig : ScriptableObject
{

    [SerializeField]
    [PreviewSprite]
    private Sprite entityIcon;
    public Sprite EntityIcon { get { return entityIcon; } }

    [SerializeField]
    private string entityName;
    public string EntityName { get { return entityName; } }
}