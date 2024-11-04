using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public UnitData unitData;
    public int UnitLevel;

    [HideInInspector]
    public RaycastHit2D[] rayHits;
    [HideInInspector]
    public Vector2 rayVector;
    [HideInInspector]
    public UnitScript unitScript;
    [HideInInspector]
    public PlayerScript playerScript;

    [HideInInspector]
    public enum State {walk, attack, dead}
    //[HideInInspector]
    public State state;

    public int heart;
    public bool rangedAttack;

    Animator animator;
    Collider2D coll;

    [HideInInspector]
    public int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        animator    = gameObject.GetComponent<Animator>();
        coll        = gameObject.GetComponent<Collider2D>();
    }

    void OnEnable()
    {
        state = State.walk;
        rayHits = new RaycastHit2D[1];
    }

    // Update is called once per frames
    void Update()
    {
        Debug.DrawRay(transform.position, rayVector*unitData.attackRange, Color.red);
        
        if(state == State.walk)
        {
            if(!rangedAttack) rayHits[0] = Physics2D.Raycast(transform.position, rayVector, unitData.attackRange, layerMask);
            else rayHits = Physics2D.RaycastAll(transform.position, rayVector, unitData.attackRange, layerMask);
            if(rayHits[0]) 
            {
                if(!animator.GetBool("attack")) animator.SetBool("attack", true);
            }
            else 
            {
                if(animator.GetBool("attack")) animator.SetBool("attack", false);
                transform.Translate(Vector3.right*unitData.speedLevel[UnitLevel]*Time.deltaTime/10);
            }
        }
    }
    void AttackEvent()
    {
        foreach (RaycastHit2D rayHit in rayHits)
        {
            if(rayHit)
            {
                try
                {
                    unitScript = rayHit.transform.gameObject.GetComponent<UnitScript>();
                    unitScript.heart -= unitData.powerLevel[UnitLevel];
                    unitScript.Hit();
                }
                catch (NullReferenceException)
                {
                    playerScript = rayHit.transform.gameObject.GetComponent<PlayerScript>();
                    GameManager.instance.PlayerHPs[Convert.ToInt32(!playerScript.MyPlayer)] -= unitData.powerLevel[UnitLevel];
                    playerScript.Hit();
                }
            }
        }
    }

    IEnumerator Dead()
    {
        state = State.dead;
        animator.SetTrigger("dead");

        coll.enabled = false;
        if(LayerMask.LayerToName(gameObject.layer) == "EnemyUnit")
        {
            GameManager.instance.coin += unitData.spawnCost;
            GameManager.instance.coinText.text = GameManager.instance.coin.ToString();
        }

        yield return new WaitForSeconds(2);
        
        gameObject.SetActive(false);

        yield break;
    }
    public void Hit()
    {
        if(heart > 0)
        {
            //animator.SetTrigger("hit");
        }else
        {
            if(state != State.dead)
            {
                StartCoroutine("Dead");
            }
        }
    }
}
