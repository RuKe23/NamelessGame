using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choosebutton : MonoBehaviour
{
    public GameObject choose;

    public GameObject cancel;

    public GameObject choose2;

    public GameObject cancel2;

    public void click()
    {
        choose.SetActive(false);

        cancel.SetActive(true);

        choose2.SetActive(true);

        cancel2.SetActive(false);
    }
        
}
