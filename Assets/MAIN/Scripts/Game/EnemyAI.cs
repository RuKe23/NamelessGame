using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    UnitData[] spawnUnits;

    GameObject spawnUnit;
    UnitScript spawnUnitScript;

    Vector3 spawnPosition;

    public float[] spawnUnit_Num = new float[5];
    public float[] coolTime_Num = new float[5];
    public float coolTimeRandomN;
    public int TiemOut;

    public int spawnPhase = 0;

    int spawnUnitsRange;

    float backgroundLength;
    int layerMask;


    void Start()
    {
        backgroundLength= GameManager.instance.stageData.backgroundLength;
        spawnUnits      = GameManager.instance.stageData.appearsEnemy;
        spawnPosition   = new Vector3(-backgroundLength/2, 0, 0);
        spawnUnitsRange = spawnUnits.Length-1;

        layerMask = LayerMask.GetMask("FriendlyUnit");
        StartCoroutine("spwanAI");
        StartCoroutine(EnemySpwan(GameManager.instance.stageData.appearsEnemy[0]));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.right*backgroundLength/2, Color.red);
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
        spawnUnitScript.layerMask = layerMask;
        
        spawnUnitScript.rayVector = Vector2.right;
        spawnUnitScript.heart = unitData.heartLevel[0];

        spawnUnit.GetComponent<Animator>().runtimeAnimatorController = unitData.animatorController;

        spawnUnit.transform.gameObject.layer = LayerMask.NameToLayer("EnemyUnit");

        spawnUnit.GetComponent<Collider2D>().enabled = true;
    }

    public int endSetTime;
    public int delayMax;
    public int winding;

    float extraTime = 0;

    // 초반에 조금씩 나오다가 일정 수준 다가오면 1차 공격
    // 1차 공격을 버텨내고 한번 성을 공격하면 2차 공격
    // 2차 공격을 버텨내고 성의 체력을 절반 이상 깎으면 3차(마치막)
    // 코인만 버는것을 피하기 위해 게임을 시작한지 특정 시간이 지나면 매우 어려운 4차 공격
    //endtime 300s

    void NextPhase()
    {
        spawnPhase += 1;

        int Enemy_Length = GameManager.instance.stageData.appearsEnemy.Length-1;

        for (int i = Mathf.FloorToInt(spawnUnit_Num[spawnPhase-1]*Enemy_Length); i <= Mathf.FloorToInt(spawnUnit_Num[spawnPhase]*Enemy_Length); i++)
        {
            StartCoroutine(EnemySpwan(GameManager.instance.stageData.appearsEnemy[i]));
        }
    }

    IEnumerator spwanAI()
    {
        yield return new WaitUntil(() => Physics2D.Raycast(transform.position, Vector2.right, backgroundLength*0.3f, layerMask));
        NextPhase();

        yield return new WaitUntil(() => GameManager.instance.PlayerHPs[1] != GameManager.instance.stageData.EnemyPlayerHP);
        NextPhase();

        yield return new WaitUntil(() => GameManager.instance.PlayerHPs[1] < GameManager.instance.stageData.EnemyPlayerHP/2);
        NextPhase();

        // if(rayHit) extraTime += (1 - rayHit.distance/backgroundLength)*10;
        // yield return new WaitForSeconds(3);
        // while(true)
        // {
        //     int velue = InvRayleighCdf(Random.value, spawnUnitsRange, (int)(Time.time*spawnUnitsRange/endSetTime), (int)(Time.time/(endSetTime/10)));
        //     print(velue);
        //     SpownEvent(spawnUnits[velue]);
        //     yield return new WaitForSeconds(2*winding*delayMax/(Time.time+extraTime+winding)*Random.value*0.5f);
        // }
    }
    IEnumerator EnemySpwan(UnitData unitData)
    {
        while(true)
        {
            SpownEvent(unitData);
            yield return new WaitForSeconds(unitData.spawnTime*(1-(Random.value*coolTimeRandomN))*coolTime_Num[spawnPhase]);
        }
    }
}
