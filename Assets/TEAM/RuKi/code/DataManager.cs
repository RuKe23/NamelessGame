using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class UnitList
{
    public int level;
    public bool unlock;
    public UnitData unitData;
}

[System.Serializable]
public class ItemList
{
    public int level;

    [Range(0.0f, 1.0f)]
    public float progress;

    public ItemData itemData;
}

[System.Serializable]
public class StageList
{
    public bool clear;
    public StageData stageData;
}

[System.Serializable]
public class ChallengeList
{
    [Range(0.0f, 1.0f)]
    public float progress;
    public ChallengeData challengeData;
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
    
    [SerializeField]
    private ObjectListData objectListData;
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

    delegate T delegateIndex<T>( int i );
    [ContextMenu("DeleteData")]
    private void DeleteGameData()
    {
        if (PlayerPrefs.HasKey("GameData"))
        {
            PlayerPrefs.DeleteKey("GameData");
        }
        LoadGameData();

        ResetGameDate<UnitList, UnitData>(gameData.unitList, objectListData.unitDataList, (i) => gameData.unitList[i].unitData);
        // gameData.unitList       = new UnitList[5];
        // gameData.itemList       = GetComponent<ItemList[]>()[5];
        // gameData.stageList      = GetComponent<UnitList[]>()[5];
        // gameData.challengeList      = GetComponent<UnitList[]>()[5];
        
        // for (int i=0;i<gameData.unitList.Length;i++)      
        // {
        //     gameData.unitList[i]                    = GetComponent<UnitList>();
        //     gameData.unitList[i].unitData           = objectListData.unitDataList[i];
        // }
        // for (int i=0;i<gameData.itemList.Length;i++)      
        // {
        //     gameData.itemList[i]                    = GetComponent<ItemList>();
        //     gameData.itemList[i].itemData           = objectListData.itemDataList[i];
        // }
        // for (int i=0;i<gameData.stageList.Length;i++)     
        // {
        //     gameData.unitList[i]                    = GetComponent<UnitList>();
        //     gameData.stageList[i].stageData         = objectListData.stageDataList[i];
        // }
        // for (int i=0;i<gameData.challengeList.Length;i++) 
        // {
        //     gameData.unitList[i]                    = GetComponent<UnitList>();
        //     gameData.challengeList[i].challengeData = objectListData.challengeDataList[i];
        // }

        SaveGameData();
    }

    private void ResetGameDate<list, data>(list[] indexList, data[] dataList, delegateIndex<data> indexData)
    {
        indexList = new list[dataList.Length];

        for (int i=0;i<indexList.Length;i++)      
        {
            indexList[i] = GetComponent<list>();
            
            Debug.Log(indexData(i));
            //int = dataList[i];
        }
    }
}