using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    void Awake()
    {
        instance = this;
    }

    //[HideInInspector]
    public StageData stageData;

    public PoolManager poolManager;

    [Header("Main Data")]
    public int coin;
    public Vector2Int PlayerHPs;

    [Header("Text UI")]
    public Text coinText;

    public void GameEnd(bool myTeam)
    {
        if(myTeam) print("승리");
        else print("패배");
    }

    void Start()
    {
        coinText.text = coin.ToString();
        PlayerHPs[0] = 10000;
        PlayerHPs[1] = stageData.EnemyPlayerHP;
    }

    //이정도 까지는 필요없을 것 같다.

    // private static GameManager _instance;
    // public static GameManager Instance
    // {
    //     get
    //     {
    //         if (_instance == null)
    //         {
    //             _instance = FindObjectOfType<GameManager>();
    //         }
    //         return _instance;
    //     }
    // }
 
    // public GameObject poop;
    // public Transform objbox;
 
    // void Start()
    // {
    //     StartCoroutine(CreatepoopRoutine());
    // }
 
    // IEnumerator CreatepoopRoutine()
    // {
    //     while (true)
    //     {
    //         CreatePoop();
    //         yield return new WaitForSeconds(0.3f);
    //     }
    // }
 
    // private void CreatePoop()
    // {
    //     Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 5.0f));
    //     GameObject obj = Instantiate(poop, pos, Quaternion.identity);
    //     obj.transform.parent = objbox.transform;
    // }
}