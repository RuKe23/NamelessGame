using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class spawn : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            GameManager.instance.pool.Get(0);
        }    
    }
}
