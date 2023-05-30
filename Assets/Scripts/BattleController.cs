using UnityEngine;

public class BattleController : MonoBehaviour
{
    private GameObject battleGround;
    public GameObject baseUnitRedPrefab;
    public GameObject baseUnitBluePrefab;

    public GameObject unitArcherPrefab;

    private CanvasUIMaster canvasUIMaster;

    private int totalPlayerUnit, totalEnemyUnit = 0;
    private float totalTime = 120f; //2 minutes

    void sysInit()
    {
        canvasUIMaster = FindObjectOfType<CanvasUIMaster>();
        if (!canvasUIMaster)
        {
            print("[ERR] Canvas Master not assigned!");
        }
    }

    void battleInit()
    {
        getBattleGround();
        respawnUnits();
        totalPlayerUnit = getNumPlayerUnit();
        totalEnemyUnit = getNumEnemyUnit();
    }

    void unitMonitor()
    {
        canvasUIMaster.setPlayerHealthBar(getNumPlayerUnit(), totalPlayerUnit);
        canvasUIMaster.setEnemyHealthBar(getNumEnemyUnit(), totalEnemyUnit);
    }

    void Start()
    {
        sysInit();
        battleInit();
        InvokeRepeating("unitMonitor", 1f, 1f); //1s delay, repeat every 1s
    }


    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        UpdateLevelTimer(totalTime);
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        canvasUIMaster.updateTimeText(minutes.ToString("00") + ":" + seconds.ToString("00"));
    }

    private int getNumPlayerUnit()
    {
        return GameObject.FindGameObjectsWithTag("Player").Length;
    }

    private int getNumEnemyUnit()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void getBattleGround()
    {
        if (battleGround == null)
            battleGround = GameObject.FindGameObjectWithTag("BattleGround");
    }

    void respawnUnits()
    {
        for (int posY = 8; posY < 13; posY++)
        {
            for (int posX = -20; posX < -17; posX++)
            {
                GameObject _baseUnit = Instantiate(baseUnitBluePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(false);
                _baseUnit.GetComponent<BaseUnit>().groupNum = 1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.tag = "Player";
            }
        }

        for (int posY = -5; posY < 0; posY++)
        {
            for (int posX = -15; posX < -12; posX++)
            {
                GameObject _baseUnit = Instantiate(baseUnitBluePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(false);
                _baseUnit.GetComponent<BaseUnit>().groupNum = 1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.tag = "Player";
            }
        }


        for (int posY = -10; posY < 5; posY++)
        {
            for (int posX = -20; posX < -17; posX++)
            {
                GameObject _baseUnit = Instantiate(baseUnitBluePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(false);
                _baseUnit.GetComponent<BaseUnit>().groupNum = 1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.tag = "Player";
            }
        }


        for (int posY = -18; posY < -13; posY++)
        {
            for (int posX = -20; posX < -17; posX++)
            {
                GameObject _baseUnit = Instantiate(baseUnitBluePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(false);
                _baseUnit.GetComponent<BaseUnit>().groupNum = 1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.tag = "Player";
            }
        }


        //Enemy


        for (int posY = 4; posY < 10; posY++)
        {
            for (int posX = 12; posX < 15; posX++)
            {
                GameObject _baseUnit = Instantiate(baseUnitRedPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(true);
                _baseUnit.GetComponent<BaseUnit>().groupNum = -1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.GetComponent<BaseUnit>().tag = "Enemy";
            }
        }

        for (int posY = -15; posY < -9; posY++)
        {
            for (int posX = 12; posX < 15; posX++)
            {
                GameObject _baseUnit = Instantiate(baseUnitRedPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(true);
                _baseUnit.GetComponent<BaseUnit>().groupNum = -1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.GetComponent<BaseUnit>().tag = "Enemy";
            }
        }


        for (int posY = -5; posY < 0; posY++)
        {
            for (int posX = 12; posX < 15; posX++)
            {
                GameObject _baseUnit = Instantiate(baseUnitRedPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(true);
                _baseUnit.GetComponent<BaseUnit>().groupNum = -1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(8f, 15f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.GetComponent<BaseUnit>().tag = "Enemy";
            }
        }

        for (int posY = 9; posY < 12; posY++)
        {
            for (int posX = 20; posX < 22; posX++)
            {
                GameObject _baseUnit = Instantiate(unitArcherPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(true);
                _baseUnit.GetComponent<BaseUnit>().groupNum = -1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(25f, 35f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.GetComponent<BaseUnit>().tag = "Enemy";
            }
        }

        for (int posY = 3; posY < 6; posY++)
        {
            for (int posX = 20; posX < 22; posX++)
            {
                GameObject _baseUnit = Instantiate(unitArcherPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(true);
                _baseUnit.GetComponent<BaseUnit>().groupNum = -1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(25f, 35f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.GetComponent<BaseUnit>().tag = "Enemy";
            }
        }

        for (int posY = -3; posY < 0; posY++)
        {
            for (int posX = 20; posX < 22; posX++)
            {
                GameObject _baseUnit = Instantiate(unitArcherPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(true);
                _baseUnit.GetComponent<BaseUnit>().groupNum = -1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(25f, 35f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.GetComponent<BaseUnit>().tag = "Enemy";
            }
        }

        for (int posY = -9; posY < -6; posY++)
        {
            for (int posX = 20; posX < 22; posX++)
            {
                GameObject _baseUnit = Instantiate(unitArcherPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(true);
                _baseUnit.GetComponent<BaseUnit>().groupNum = -1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(25f, 35f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.GetComponent<BaseUnit>().tag = "Enemy";
            }
        }

        for (int posY = -15; posY < -12; posY++)
        {
            for (int posX = 20; posX < 22; posX++)
            {
                GameObject _baseUnit = Instantiate(unitArcherPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                _baseUnit.transform.parent = battleGround.transform;
                _baseUnit.GetComponent<BaseUnit>().Filp(true);
                _baseUnit.GetComponent<BaseUnit>().groupNum = -1;
                _baseUnit.GetComponent<BaseUnit>().weaponDamage = Random.Range(25f, 35f);
                _baseUnit.GetComponent<BaseUnit>().baseHealth = 100f;
                _baseUnit.GetComponent<BaseUnit>().tag = "Enemy";
            }
        }
    }
}