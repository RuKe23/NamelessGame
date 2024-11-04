using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public bool MyPlayer;
    public int heart;

    public void Hit()
    {
        if(GameManager.instance.PlayerHPs[Convert.ToInt32(MyPlayer)] > 0)
        {
            //animator.SetTrigger("hit");
        }else
        {
            GameManager.instance.GameEnd(MyPlayer);
        }
    }
}
