using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public UnitData unitData;
    public int UnitLevel;

    [HideInInspector]
    public RaycastHit2D rayHit;
    [HideInInspector]
    public Vector2 rayVector;
    [HideInInspector]
    public UnitScript unitScript;

    [HideInInspector]
    public enum State {walk, attack, dead}
    //[HideInInspector]
    public State state;

    public int heart;

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
    }

    // Update is called once per frames
    void Update()
    {
        Debug.DrawRay(transform.position, rayVector*unitData.attackRange, Color.red);
        
        if(state == State.walk)
        {
            rayHit = Physics2D.Raycast(transform.position, rayVector, unitData.attackRange, layerMask);
            if(rayHit) 
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
        unitScript = rayHit.transform.gameObject.GetComponent<UnitScript>();
        unitScript.heart -= unitData.powerLevel[UnitLevel];
        unitScript.Hit();
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
                StopCoroutine("walk");
                StopCoroutine("attack");

                StartCoroutine("Dead");
            }
        }
    }
}
