using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩 보관 변수
    public GameObject[] prefabs;
    // 풀 담당 리스트
    List<GameObject>[] pools;   

    void Awake()
    {
        // 풀 안에 있는 배열 초기화
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++) {
            // 배열 안에 있는 리스트 초기화
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        return select;
    }
}
