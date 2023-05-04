using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class BaseUnit : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isMine = true;
    public Color spriteColor;

    public int groupNum { get; set; }

    public float weaponDamage = 2;
    public float baseHealth = 100;

    private float attactElapsed = 0;

    enum States
    {
        IDLE,
        RUN,
        ATTACK,
        STUCK
    };

    private States unitState;
    private GameObject targetedUnit = null;

    private Transform closestEnemy = null;
    
    private Vector2 velocity;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteR;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector2(0f, isMine? 2.1f : -2.1f);
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.color = spriteColor;
        unitState = States.RUN;
    }

    // Update is called once per frame
    void Update()
    {
        
        // RaycastHit2D foundHit = Physics2D.Raycast(transform.position, transform.up, 2, 1<<8);
        // if (foundHit.collider != null)
        // {
        //     print("Found hit");
        //     unitState = States.IDLE;
        //     
        // }

        Debug.DrawRay(transform.position,transform.up , Color.green);
        
        switch (unitState)
        {
            case States.IDLE:
                //m_Anim.Play("Idle");
                break;
            case States.RUN:
                //m_Anim.Play("Run");
                break;
            case States.ATTACK:
                //m_Anim.Play("Attack");
                AttackActions();
                break;
            case States.STUCK:
                break;
        }
    }

    
    private void AttackActions()
    {
        attactElapsed += Time.deltaTime;
        if (attactElapsed >= .5f)
        {
            attactElapsed %= .5f;
            if (targetedUnit != null && targetedUnit.GetComponent<BaseUnit>())
            {
                //m_effect.PlayAttackAudio();
                targetedUnit.GetComponent<BaseUnit>().updateDamage(weaponDamage);
            }
        }
    }

    private Transform GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        BaseUnit[] units = FindObjectsOfType(typeof(BaseUnit)) as BaseUnit[];
        
        if (units.Length <= 1)
        {
            unitState = States.RUN;
            return null;
        }

        foreach (BaseUnit unit in units)
        {
            if (groupNum != unit.groupNum * -1) continue;
            
            Vector2 directionToTarget = unit.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = unit.transform;
            }
        }

        return bestTarget;
    }

    public void Filp(bool bLeft)
    {
        isMine = bLeft;
        transform.localScale = new Vector3(bLeft ? 1 : -1, 1, 1);
    }

    void NotifyingTeam()
    {
        BaseUnit[] units = FindObjectsOfType(typeof(BaseUnit)) as BaseUnit[];
        foreach (BaseUnit unit in units)
        {
            if (groupNum == unit.groupNum)
            {
                unit.unitState = States.ATTACK;
            }
        }
    }

   
    public GameObject GetOpponentTargetUnit()
    {
        return targetedUnit;
    }

    public void updateDamage(float damage)
    {
        baseHealth -= damage;
        updateColor();
        //m_healthBar.setHealthBar(baseHealth / 50);
        if (baseHealth <= 0)
        {
            unitState = States.IDLE;
            Destroy(gameObject);
        }
    }
    
    private void updateColor()
    {
        float alpha = baseHealth / 50;
        spriteR.color = new Color(spriteR.color.r, spriteR.color.g, spriteR.color.b, alpha);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (!col.gameObject.CompareTag(gameObject.tag))
        {
            targetedUnit = col.gameObject;
            unitState = States.ATTACK;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        unitState = States.RUN;
        targetedUnit = null;
    }
    void FixedUpdate()
    {
        if (unitState == States.RUN)
        {
            rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
        }
    }
}