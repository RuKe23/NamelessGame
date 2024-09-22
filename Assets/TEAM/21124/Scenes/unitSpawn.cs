using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnPoint;
    public int spawnunit;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick() 
    {
        Spawn();
    }

    void Spawn()
    {
        GameObject unit = SubGameManager.instance.pool.Get(spawnunit);
        unit.transform.position = spawnPoint.position;
    }
}