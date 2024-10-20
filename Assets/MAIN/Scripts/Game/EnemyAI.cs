using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    UnitData[] spawnUnits;

    GameObject spawnUnit;
    UnitScript spawnUnitScript;

    Vector3 spawnPosition;

    int spawnUnitsRange;


    void Start()
    {
        spawnUnits      = GameManager.instance.stageData.appearsEnemy;
        spawnPosition   = new Vector3(-GameManager.instance.stageData.backgroundLength/2, 0, 0);
        spawnUnitsRange = spawnUnits.Length-1;

        StartCoroutine("spwanAI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int InvRayleighCdf(float u, int range, int average, int Distribution)
    {
        int index = (int)((-(Distribution/10.0f)*Mathf.Log(1/u-1))+average);
        if(index < 0) index = 0;
        else if(index > range) index = range;
        return index;
    }

    void SpownEvent(UnitData unitData)
    {
        spawnUnit = GameManager.instance.poolManager.Get(0);

        spawnUnit.transform.position = spawnPosition;
        spawnUnit.transform.rotation = Quaternion.Euler(0, 0, 0);

        spawnUnitScript = spawnUnit.GetComponent<UnitScript>();
        spawnUnitScript.unitData = unitData;
        spawnUnitScript.UnitLevel = 0;
        spawnUnitScript.layerMask = LayerMask.GetMask("FriendlyUnit");
        
        spawnUnitScript.rayVector = Vector2.right;
        spawnUnitScript.rayHit = Physics2D.Raycast(spawnPosition, spawnUnitScript.rayVector, unitData.attackRange, spawnUnitScript.layerMask);
        spawnUnitScript.heart = unitData.heartLevel[0];

        spawnUnit.GetComponent<Animator>().runtimeAnimatorController = unitData.animatorController;

        spawnUnit.transform.gameObject.layer = LayerMask.NameToLayer("EnemyUnit");

        spawnUnit.GetComponent<Collider2D>().enabled = true;
    }

    public int endSetTime;
    public int delayMax;
    public int winding;

    //endtime 300s
    IEnumerator spwanAI()
    {
        yield return new WaitForSeconds(3);
        while(true)
        {
            int velue = InvRayleighCdf(Random.value, spawnUnitsRange, (int)(Time.time*spawnUnitsRange/endSetTime), (int)(Time.time/(endSetTime/10)));
            print(velue);
            SpownEvent(spawnUnits[velue]);
            yield return new WaitForSeconds(2*winding*delayMax/(Time.time+winding)*Random.value*0.5f);
        }
    }
}
