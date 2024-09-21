using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class UnitList
{
    [HideInInspector]
    public string name;
    public int level;
    public bool unlock;
    public UnitData unitData;

    public void Validate()
    {
        name = unitData && unitData.unitName != "" ? unitData.unitName : "이름 값이 없습니다!";
    }
}

[System.Serializable]
public class ItemList
{
    [HideInInspector]
    public string name;
    public int level;
    public int progress;
    public ItemData itemData;

    public void Validate()
    {
        name = itemData && itemData.itemName != "" ? itemData.itemName : "이름 값이 없습니다!";
    }
}

[System.Serializable]
public class StageList
{
    [HideInInspector]
    public string name;
    public bool clear;
    public StageData stageData;

    public void Validate()
    {
        name = stageData && stageData.stageName != "" ? stageData.stageName : "이름 값이 없습니다!";
    }
}

[System.Serializable]
public class ChallengeList
{
    [HideInInspector]
    public string name;
    public int progress;
    public ChallengeData challengeData;

    public void Validate()
    {
        name = challengeData && challengeData.challengeName != "" ? challengeData.challengeName : "이름 값이 없습니다!";
    }
}

[System.Serializable]
public class GameData
{
    [Header("Money Data")]
    public int organic;
    public int coin;

    [Header("List Data")]
    public UnitList[] unitList;
    public ItemList[] itemList;
    public StageList[] stageList;
    public ChallengeList[] challengeList;

    [Header("etc")]
    public UnitData[] combatUnit;
    public int storyProgress;
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    
    public GameData gameData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        LoadGameData();
    }

    private void OnApplicationQuit()
    {
        //SaveGameData();
    }

    private void OnValidate()
    {
        for (int i = 0; i < gameData.unitList.Length; i++) gameData.unitList[i].Validate();
        for (int i = 0; i < gameData.itemList.Length; i++) gameData.itemList[i].Validate();
        for (int i = 0; i < gameData.stageList.Length; i++) gameData.stageList[i].Validate();
        for (int i = 0; i < gameData.challengeList.Length; i++) gameData.challengeList[i].Validate();
    }


    [ContextMenu("SaveData")]
    private void SaveGameData()
    {
        string jsonData = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", jsonData);
        PlayerPrefs.Save();
    }

    [ContextMenu("LoadData")]
    private void LoadGameData()
    {
        if (PlayerPrefs.HasKey("GameData"))
        {
            string jsonData = PlayerPrefs.GetString("GameData");
            gameData = JsonUtility.FromJson<GameData>(jsonData);
        }
    }

    [ContextMenu("ResetData")]
    private void ResetGameData()
    {
        if(EditorUtility.DisplayDialog("ResetData", "데이터를 초기화하시겠습니까?", "확인", "취소"))
        {
            if (PlayerPrefs.HasKey("BaseGameData"))
            {
                string jsonData = PlayerPrefs.GetString("BaseGameData");
                PlayerPrefs.SetString("GameData", jsonData);
                PlayerPrefs.Save();

                LoadGameData();
            }
            else
            {
                EditorUtility.DisplayDialog("Erorr", "데이터가 없습니다.", "확인");
            }
        }
        OnValidate();
    }

    [ContextMenu("SetBaseData")]
    private void SetBaseData()
    {
        if(EditorUtility.DisplayDialog("SetBaseData", "베이트데이터를 수정하시겠습니까?\n충돌 가능성이 높으므로 충분한 상의 후 진행해주세요.", "확인", "취소"))
        {
        string jsonData = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("BaseGameData", jsonData);
        PlayerPrefs.Save();

        EditorUtility.DisplayDialog("완료", "베이스데이터를 수정하였습니다.\n충돌이 일어나지 않기를 바랍니다.", "확인");
        }
    }
}