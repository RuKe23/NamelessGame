using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitButtonSet : MonoBehaviour
{
    public UnitButtonPressEvent[] pressEvents;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pressEvents.Length; i++)
        {
            pressEvents[i].unitList = DataManager.Instance.gameData.combatUnit[i];
            pressEvents[i].GetComponentsInChildren<Image>()[1].sprite = 
            DataManager.Instance.gameData.combatUnit[i].unitData.unitIcon;
            pressEvents[i].GetComponentInChildren<Text>().text = 
            DataManager.Instance.gameData.combatUnit[i].unitData.spawnCost.ToString();
        }
    }
}
