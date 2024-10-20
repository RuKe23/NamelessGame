using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitButtonPressEvent : MonoBehaviour
{
    [SerializeField]
    Image disable;

    [HideInInspector]
    public UnitList unitList;

    GameObject spawnUnit;
    UnitScript spawnUnitScript;

    Vector3 spawnPosition;

    float CoolTime = 0.0f;

    void Start()
    {
        spawnPosition   = new Vector3(GameManager.instance.stageData.backgroundLength/2, 0, 0);
    }

    void Update()
    {
        if(CoolTime > 0.0f)
        {
            CoolTime -= Time.deltaTime;
            disable.fillAmount = CoolTime / unitList.unitData.spawnTime;
        }
    }

    public void SpownEvent()
    {
        if(CoolTime <= 0.0f && GameManager.instance.coin >= unitList.unitData.spawnCost)
        {
            spawnUnit = GameManager.instance.poolManager.Get(0);

            spawnUnit.transform.position = spawnPosition;
            spawnUnit.transform.rotation = Quaternion.Euler(0, 180, 0);

            spawnUnitScript = spawnUnit.GetComponent<UnitScript>();
            spawnUnitScript.unitData = unitList.unitData;
            spawnUnitScript.UnitLevel = unitList.level;
            spawnUnitScript.layerMask = LayerMask.GetMask("EnemyUnit");
            
            spawnUnitScript.rayVector = Vector2.left;
            spawnUnitScript.rayHit = Physics2D.Raycast(spawnPosition, spawnUnitScript.rayVector, unitList.unitData.attackRange, spawnUnitScript.layerMask);
            spawnUnitScript.heart = unitList.unitData.heartLevel[unitList.level];

            spawnUnit.GetComponent<Animator>().runtimeAnimatorController = unitList.unitData.animatorController;
        
            GameManager.instance.coin -= unitList.unitData.spawnCost;
            GameManager.instance.coinText.text = GameManager.instance.coin.ToString();
            CoolTime = unitList.unitData.spawnTime;

            spawnUnit.transform.gameObject.layer = LayerMask.NameToLayer("FriendlyUnit");

            spawnUnit.GetComponent<Collider2D>().enabled = true;
        }
    }
}
