using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelbutton : MonoBehaviour
{
    public GameObject choose;

    public GameObject cancel;


    public void click()
    {
        choose.SetActive(true);

        cancel.SetActive(false);

    }
}
