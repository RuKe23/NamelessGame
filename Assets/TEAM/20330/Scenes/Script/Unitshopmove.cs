using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unitshopmove : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Unitshop");
    }
}