using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    private GameObject battleGround;
    public GameObject baseUnitPrefab;

    void Start()
    {
        getBattleGround();
        respawnUnits();
        
        //InvokeRepeating("respawnUnits", 0.5f, 25f); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    void getBattleGround()
    {
        if (battleGround == null)
            battleGround = GameObject.FindGameObjectWithTag("BattleGround");
    }

    void respawnUnits()
    {

        //
        // GameObject _baseUnit = Instantiate(baseUnitPrefab, new Vector3(-4, 4, 0), Quaternion.identity);
        // _baseUnit.transform.parent = battleGround.transform;
        // _baseUnit = Instantiate(baseUnitPrefab, new Vector3(-4, 3, 0), Quaternion.identity);
        // _baseUnit.transform.parent = battleGround.transform;
        // _baseUnit = Instantiate(baseUnitPrefab, new Vector3(-4, 2, 0), Quaternion.identity);
        // _baseUnit.transform.parent = battleGround.transform;
        // _baseUnit = Instantiate(baseUnitPrefab, new Vector3(-4, 1, 0), Quaternion.identity);
        // _baseUnit.transform.parent = battleGround.transform;
        // _baseUnit = Instantiate(baseUnitPrefab, new Vector3(-4, 0, 0), Quaternion.identity);
        // _baseUnit.transform.parent = battleGround.transform;
        int i = 0;
        for (i = 4; i < 8; i++)
        {

            GameObject _baseUnit = Instantiate(baseUnitPrefab, new Vector3(Random.Range(-15f ,-12f), i, 0), Quaternion.identity);
            _baseUnit.transform.parent = battleGround.transform;
            _baseUnit.GetComponent<BaseUnit>().Filp(false);
            _baseUnit.GetComponent<BaseUnit>().groupNum = 1;
            _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
            _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
            _baseUnit.tag = "Player";
        }
  
      

        
        for ( i = -2; i < 3; i++)
        {
         
            GameObject _baseUnit = Instantiate(baseUnitPrefab, new Vector3(Random.Range(-15f ,-12f), i, 0), Quaternion.identity);
            _baseUnit.transform.parent = battleGround.transform;
            _baseUnit.GetComponent<BaseUnit>().Filp(false);
            _baseUnit.GetComponent<BaseUnit>().groupNum = 2;
            _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
            _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
            _baseUnit.tag = "Player";
        }
        
        for ( i = -8; i < -3; i++)
        {
         
            GameObject _baseUnit = Instantiate(baseUnitPrefab, new Vector3(-6, i, 0), Quaternion.identity);
            _baseUnit.transform.parent = battleGround.transform;
            _baseUnit.GetComponent<BaseUnit>().Filp(false);
            _baseUnit.GetComponent<BaseUnit>().groupNum = 3;
            _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
            _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
            _baseUnit.tag = "Player";
        }
        
        
        
        
        //Enemy
        
        
        // GameObject temp = Instantiate(baseUnitPrefab, new Vector3(10, 5, 0), Quaternion.identity);
        // temp.transform.parent = battleGround.transform;
        // temp.GetComponent<BaseUnit>().Filp(true);
        // temp.GetComponent<BaseUnit>().groupNum = -1;
        // temp.GetComponent<BaseUnit>().weaponDamage = 21.2f;
        // temp.GetComponent<BaseUnit>().baseHealth = 100f;
        // temp.tag = "Enemy";
        //
        
        for (i = 4; i < 8; i++)
        {

            GameObject _baseUnit = Instantiate(baseUnitPrefab, new Vector3(Random.Range(12f ,15f), i, 0), Quaternion.identity);
            _baseUnit.transform.parent = battleGround.transform;
            _baseUnit.GetComponent<BaseUnit>().Filp(true);
            _baseUnit.GetComponent<BaseUnit>().groupNum = -1;
            _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
            _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
            _baseUnit.GetComponent<BaseUnit>().tag = "Enemy";
        }
        
        for ( i = -2; i < 3; i++)
        {
         
            GameObject _baseUnit = Instantiate(baseUnitPrefab, new Vector3(Random.Range(12f ,15f), i, 0), Quaternion.identity);
            _baseUnit.transform.parent = battleGround.transform;
            _baseUnit.GetComponent<BaseUnit>().Filp(true);
            _baseUnit.GetComponent<BaseUnit>().groupNum = -2;
            _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
            _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
            _baseUnit.GetComponent<BaseUnit>().tag = "Enemy";
        }
        
        for ( i = -8; i < -3; i++)
        {
         
            GameObject _baseUnit = Instantiate(baseUnitPrefab, new Vector3(Random.Range(12f ,15f), i, 0), Quaternion.identity);
            _baseUnit.transform.parent = battleGround.transform;
            _baseUnit.GetComponent<BaseUnit>().Filp(true);
            _baseUnit.GetComponent<BaseUnit>().groupNum = -3;
            _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
            _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
            _baseUnit.tag = "Enemy";
        }
        
        return;
        
        
        
        //Dummy Enemy;
        // GameObject temp = Instantiate(baseUnitPrefab, new Vector3(10, 0, 0), Quaternion.identity);
        // temp.transform.parent = battleGround.transform;
        // temp.GetComponent<BaseUnit>().setScale(new Vector3(2.0f,2.0f,2.0f));
        // temp.GetComponent<BaseUnit>().Filp(true);
        // temp.GetComponent<BaseUnit>().groupNum = 4;
        //
        //
        // temp = Instantiate(baseUnitPrefab, new Vector3(14, 5, 0), Quaternion.identity);
        // temp.transform.parent = battleGround.transform;
        // temp.GetComponent<BaseUnit>().setScale(new Vector3(2.0f,2.0f,2.0f));
        // temp.GetComponent<BaseUnit>().Filp(true);
        // temp.GetComponent<BaseUnit>().groupNum = 5;
        
        for (i = 4; i < 9; i++)
        {

            GameObject _baseUnit = Instantiate(baseUnitPrefab, new Vector3(10, i, 0), Quaternion.identity);
            _baseUnit.transform.parent = battleGround.transform;
            _baseUnit.GetComponent<BaseUnit>().Filp(true);
            _baseUnit.GetComponent<BaseUnit>().groupNum = -1;
        }

        
        for ( i = -2; i < 3; i++)
        {
         
            GameObject _baseUnit = Instantiate(baseUnitPrefab, new Vector3(10, i, 0), Quaternion.identity);
            _baseUnit.transform.parent = battleGround.transform;
            _baseUnit.GetComponent<BaseUnit>().Filp(true);
            _baseUnit.GetComponent<BaseUnit>().groupNum = -2;
        }
        
        for ( i = -8; i < -3; i++)
        {
         
            GameObject _baseUnit = Instantiate(baseUnitPrefab, new Vector3(10, i, 0), Quaternion.identity);
            _baseUnit.transform.parent = battleGround.transform;
            _baseUnit.GetComponent<BaseUnit>().Filp(true);
            _baseUnit.GetComponent<BaseUnit>().groupNum = -3;
        }
        
        
        
        
    }
}