using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class BaseUnit : PlayerController
{
    // Start is called before the first frame update

    private bool isLeft = true;
    //private BattleUnitHealthBar m_healthBar;

    public int groupNum { get; set; }

    public float weaponDamage = 0;
    public float baseHealth = 0;

    protected float attactElapsed = 0;
    private float moveSpeed = 4.1f;

    
    protected UnitStates unitState;
    protected Transform closestEnemy = null;
    //private GameObject targetedUnit = null;

    void Start()
    {
        initCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy = GetClosestEnemy();
        if (closestEnemy == null)
        {
            unitState = UnitStates.RUN;
        }
        else
        {
            checkState();
        }



        performActions();
    }

    protected void initCharacter()
    {
        m_CapsulleCollider = this.transform.GetComponent<CapsuleCollider2D>();
        m_Anim = this.transform.Find("model").GetComponent<Animator>();
        m_rigidbody = this.transform.GetComponent<Rigidbody2D>();

        //m_healthBar = transform.Find("HealthBar").GetComponent<BattleUnitHealthBar>();
        //m_effect = transform.Find("Effects").GetComponent<BattleUnitEffects>();

        unitState = UnitStates.IDLE;
    }

    protected void performActions()
    {
        switch (unitState)
        {
            case UnitStates.IDLE:
                m_Anim.Play("Idle");
                break;
            case UnitStates.RUN:
                m_Anim.Play("Run");
                if (closestEnemy != null)
                {
                    transform.position = Vector2.MoveTowards(transform.position, closestEnemy.position, moveSpeed * Time.deltaTime);
                }
                else
                {
                    float dirMoveSpeed = isLeft ? moveSpeed * -1 : moveSpeed;
                    transform.Translate(Vector2.right * dirMoveSpeed * Time.deltaTime);
                }

                break;
            case UnitStates.ATTACK:
                m_Anim.Play("Attack");
                AttackActions();
                break;
            case UnitStates.STUCK:
                break;
        }
    }

    private void checkState()
    {
        float dist = Vector2.Distance(closestEnemy.position, transform.position);
        //print("Distance to other: " + dist);

        float angle = AngleTo(transform.position, closestEnemy.position);
       // print("Angle to other: " + angle);
        //if (dist < 1.3f && angle < 45f)
        if (dist < 1.3f)
        {
            unitState = UnitStates.ATTACK;
        }
        else if(dist < 1.3f && angle > 80f){
        
        }
        else
        {
            unitState = UnitStates.RUN;
        }
    }

    private float AngleTo(Vector2 pos, Vector2 target)
    {
        Vector2 diference = Vector2.zero;

        if (target.x > pos.x)
            diference = target - pos;
        else
            diference = pos - target;

        return Vector2.Angle(Vector2.right, diference);
    }

    protected virtual void AttackActions()
    {
        attactElapsed += Time.deltaTime;
        if (attactElapsed >= .5f)
        {
            attactElapsed %= .5f;
            if (closestEnemy != null)
            {
                //m_effect.PlayAttackAudio();
                closestEnemy.GetComponent<BaseUnit>().updateDamage(weaponDamage);
                FindObjectOfType<FXMaster>().Sword(closestEnemy, closestEnemy.position.x > transform.position.x ? 1 : -1, weaponDamage);
            }
        }
    }

    protected Transform GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        BaseUnit[] units = FindObjectsOfType(typeof(BaseUnit)) as BaseUnit[];

//        print("Found OBJ: " + units.Length);

        if (units.Length <= 1)
        {
            unitState = UnitStates.RUN;
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

        // if (bestTarget == null)
        // {
        //     print("bestTarget == null");
        // }
        return bestTarget;
    }

    public void Filp(bool bLeft)
    {
        isLeft = bLeft;
        transform.localScale = new Vector3(bLeft ? 1 : -1, 1, 1);
    }

    void NotifyingTeam()
    {
        BaseUnit[] units = FindObjectsOfType(typeof(BaseUnit)) as BaseUnit[];
        foreach (BaseUnit unit in units)
        {
            if (groupNum == unit.groupNum)
            {
                unit.unitState = UnitStates.ATTACK;
            }
        }
    }
    
    // public GameObject GetOpponentTargetUnit()
    // {
    //     return targetedUnit;
    // }

    public void updateDamage(float damage)
    { 
        
        
        //m_effect.PlayDamageEffect(isLeft ? -1 : 1, damage);
        baseHealth -= damage;

        //m_healthBar.setHealthBar(baseHealth / 100);
        if (baseHealth <= 0)
        {
            m_Anim.Play("Die");

            if (transform != null)
            {
                FindObjectOfType<FXMaster>().Blood(transform);    
            }
            
            //m_effect.PlayBloodEffect(isLeft ? -1 : 1);
            unitState = UnitStates.IDLE;
            Destroy(gameObject, 2f);
        }
    }

    protected override void LandingEvent()
    {
        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run") &&
            !m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            m_Anim.Play("Idle");
    }
}