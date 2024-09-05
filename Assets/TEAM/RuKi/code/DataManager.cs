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
    public float level;
    public float progress;
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

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
    }

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
    public float[] challengeProgress;
    public int storyProgress;
}