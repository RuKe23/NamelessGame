using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.gameData.coin += 10;
        Debug.Log(DataManager.Instance.gameData.unitList[0].unitData.unitName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
