using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unitSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnPoint;

    public int spawnunit;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

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
        GameObject unit = GameManager.instance.pool.Get(spawnunit);
        unit.transform.position = spawnPoint[1].position;
    }
}
