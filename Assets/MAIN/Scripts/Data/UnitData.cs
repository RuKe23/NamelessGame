using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditor.SearchService;
using UnityEngine;

[System.Serializable]
public class SkillLevel
{
    public float[] Value;
}

[CreateAssetMenu(fileName = "Unit", menuName = "Scriptble Object/UnitData")]
public class UnitData : ScriptableObject
{
    [Header("Main Info")]
    public int unitId;
    public string unitName;
    public Sprite unitIcon;

    [Header("Desc")]
    [TextArea]
    public string unitDesc;
    [TextArea]
    public string unitSkill;
    public string unlockItem;
    
    [Header("Main Data")]
    public int[] levelUpMoney       = new int[5];
    public SkillLevel[] skillLevel  = new SkillLevel[5];
    public int[] powerLevel         = new int[5];
    public int[] heartLevel         = new int[5];
    public int[] speedLevel         = new int[5];

    public float spawnTime;
    public float skillCooldown;
    public float attackSpeed;
    public float attackRange;
    
    [Header("Animation")]
    public AnimatorController animatorController;

    [Header("In Game")]
    public float attackTime;
    public int spawnCost;
}

