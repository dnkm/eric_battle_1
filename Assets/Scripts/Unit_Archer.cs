using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit_Archer : BaseUnit
{
    [SerializeField]
    private GameObject arrow;
     void Start()
    {
        initCharacter();   
    }

    void Update()
    {
        closestEnemy = GetClosestEnemy();
        if (closestEnemy != null)
        {
            unitState = UnitStates.ATTACK;
        }
        else
        {
            unitState = UnitStates.RUN;
        }

        performActions();
    }

    protected override void AttackActions()
    {
        if (attactElapsed == 0)
        {
            fireArrow();
        }

        attactElapsed += Time.deltaTime;
        if (attactElapsed >= .8f)
        {
            attactElapsed %= .8f;
            if (closestEnemy != null)
            {
                fireArrow();
            }
        }
    }

    private void fireArrow()
    {
        GameObject arrowObj = Instantiate(arrow, transform.position, Quaternion.identity);
        arrowObj.GetComponent<ProjectileArrow>().setTarget(closestEnemy, transform, groupNum, weaponDamage);
    }
}
