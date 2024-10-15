using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelbutton : MonoBehaviour
{
    public void levelup()
    {
       
        if (DataManager.Instance.gameData.coin >= 5)
        {
            DataManager.Instance.gameData.coin -= 5;
            DataManager.Instance.gameData.unitList[0].level += 1;
        }
    }
    
}
