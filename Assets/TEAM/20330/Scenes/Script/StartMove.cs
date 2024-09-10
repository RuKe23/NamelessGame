using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMove : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Start");
    }
}
