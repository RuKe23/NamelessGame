using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public Transform spawnPoint; 
    int spawnunit; 
    float timer;
    int level;

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(SubGameManager.instance.gameTime / 10f);

        if (timer > 0.5f) {
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
