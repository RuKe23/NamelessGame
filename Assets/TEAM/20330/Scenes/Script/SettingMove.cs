using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMove : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Setting");
    }
}
