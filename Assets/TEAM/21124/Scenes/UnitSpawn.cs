using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnPoint;

    public int spawnunit;

    public float SubSpawnTimeLevel;

    bool notSpawn = false;

    float timer;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick() 
    {
        if (!notSpawn) {
            Spawn();
            notSpawn = true;
        }
    }

    void Spawn()
    {
        GameObject unit = SubGameManager.instance.pool.Get(spawnunit);
        unit.transform.position = spawnPoint.position;
    }

    void Update() 
    {
        if (notSpawn) {
            timer += Time.deltaTime;

            if (timer > SubSpawnTimeLevel) {
                timer = 0;
                notSpawn = false;
            }
        }
    }
}
