using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneMove : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Lobby");
    }
}
