using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubGameManager : MonoBehaviour
{
    public static SubGameManager instance;
    public PoolManager pool;
    void Awake()
    {
        instance = this;
    }

}