using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptble Object/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Main Info")]
    public int itemId;
    public string itemName;
    public Sprite itemIcon;

    [Header("Desc")]
    [TextArea]
    public string itemDesc;
    [TextArea]
    public string itemEffect;
    [TextArea]
    public string unlockRequirement;

    public int unlockValue;

    [Header("Level Data")]
    public int[] levelUpMoney       = new int[5];
    public float[] abilityValues    = new float[5];
}
