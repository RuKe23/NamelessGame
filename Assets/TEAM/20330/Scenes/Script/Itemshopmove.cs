using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Itemshopmove : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Itemshop");
    }
}
