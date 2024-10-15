using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelbutton2 : MonoBehaviour
{
    public void levelup()
    {
       
        if (DataManager.Instance.gameData.coin >= 5)
        {
            DataManager.Instance.gameData.coin -= 5;
            DataManager.Instance.gameData.unitList[1].level += 1;
        }
    }
}
