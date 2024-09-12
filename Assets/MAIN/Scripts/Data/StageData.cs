using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Stage", menuName = "Scriptble Object/StageData")]
public class StageData : ScriptableObject
{
    [Header("Main Info")]
    public int stageId;
    public string stageName;
    public int stageDifficulty;

    [Header("Desc")]
    [TextArea]
    public string stageDesc;
    [TextArea]
    public string specialGimmick;
    public float[] gimmickValue;

    [Header("Enemy")]
    public UnitData[] appearsEnemy;

    [Header("Reward")]
    public int rewardOrganic;
    public int rewardCoin;
    public string rewardItem;
    public UnitData unlockUnit;

    [Header("etc")]
    public Vector2 stagePosition;
    public SceneAsset stageScene;
    
}
