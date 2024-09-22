using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public Transform[] spawnPoint;

    public int spawnunit; 

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        // .. 버튼 감지에 따른 프리펩 생성
        // .. 아군 생성 로직은 구상됨, but 적 생성은 아직 모름
        // .. 아군, 적군에 따라 생성 위치 다르게 조절
        timer += Time.deltaTime;

        if (timer > 0.2f) {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        SubGameManager.instance.pool.Get(spawnunit);
    }
}
