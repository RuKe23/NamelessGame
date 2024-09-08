using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public class UnitList
{
    public int level;
    public bool unlock;
}

[System.Serializable]
public class ItemList
{
    public int level;

    [Range(0.0f, 1.0f)]
    public float progress;
}

[System.Serializable]
public class GameData
{
    [Header("List Data")]
    [SerializeField]
    public UnitList[] unitList;
    [SerializeField]
    public ItemList[] itemList;

    [Header("Money Data")]
    public int organic;
    public int coin;
    
    [Header("etc")]
    public UnitData[] combatUnit;
    public bool[] stageClear;

    [Range(0.0f, 1.0f)]
    public float[] challengeProgress;
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

    [ContextMenu("DeleteData")]
    private void DeleteGameData()
    {
        if (PlayerPrefs.HasKey("GameData"))
        {
            PlayerPrefs.DeleteKey("GameData");
        }
    }    
}