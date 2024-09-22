using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnPoint;
    public int spawnunit;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    public void OnClick() 
    {
        Spawn();
    }

    void Spawn()
    {
        SubGameManager.instance.pool.Get(spawnunit);
    }
}
// .. 클릭하면 유닛정보