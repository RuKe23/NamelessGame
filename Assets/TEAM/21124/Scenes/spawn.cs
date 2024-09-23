using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public Transform spawnPoint;

    public int spawnunit; 

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f) {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject unit = SubGameManager.instance.pool.Get(spawnunit);
        unit.transform.position = spawnPoint.position;
    }
}
