using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class istr : MonoBehaviour
{
    public GameObject target;
    
    public GameObject othertar;

    public void showobj()
    {
        if (!target.activeSelf)
        {
            target.SetActive(true);
            othertar.SetActive(false);
        }

        else
        {
            target.SetActive(false);
        }


    }
}
