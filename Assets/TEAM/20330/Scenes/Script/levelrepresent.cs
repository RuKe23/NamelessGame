using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelrepresent : MonoBehaviour
{
    public Text text;

    void Start()
    {
        
    }

    void Update()
    {
        text.text=DataManager.Instance.gameData.unitList[0].level.ToString();
    }
}
