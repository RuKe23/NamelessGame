using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubGameManager : MonoBehaviour
{
    public static SubGameManager instance;
    public float gameTime;
    public float maxGameTime = 5 * 60f;
    public PoolManager pool;
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime) {
            gameTime = maxGameTime;
        }
    }
}