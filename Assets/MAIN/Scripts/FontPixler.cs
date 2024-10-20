using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontPixler : MonoBehaviour
{
    [SerializeField]
    Font[] fonts;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Font font in fonts)
        {
            font.material.mainTexture.filterMode = FilterMode.Point;
        }
    }
}
