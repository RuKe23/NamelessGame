using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject ally1_prefab;
    public GameObject ally2_prefab;
    public GameObject enemy1_prefab;
    public GameObject enemy2_prefab;

    public static Queue allys = new Queue();
    public static Queue enemys = new Queue();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject a1 = Instantiate(ally1_prefab);
            a1.transform.position = new Vector3(-5,0,0);
            allys.Enqueue(float.MaxValue);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject a2 = Instantiate(ally2_prefab);
            a2.transform.position = new Vector3(-5,0,0);
            allys.Enqueue(float.MaxValue);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject e1 = Instantiate(enemy1_prefab);
            e1.transform.position = new Vector3(5,0,0);
            enemys.Enqueue(float.MaxValue);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject e2 = Instantiate(enemy2_prefab);
            e2.transform.position = new Vector3(5,0,0);
            enemys.Enqueue(float.MaxValue);
        }
    }
}
