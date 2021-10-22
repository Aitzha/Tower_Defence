using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance = null;

    public GameObject spawnPoint;
    public GameObject[] enemies;
    public int maxEnemiesOnScreen;
    public float spawnDelay = 1f;
    public float levelsDelay = 5f;

    private float spawnDelayPassed = 1f;
    private float levelDelayPassed = 5;
    private int enemiesOnScreen = 0;
    private int curLevelEnemiesNumber = 5;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(levelDelayPassed >= levelsDelay)
        {
            if(spawnDelayPassed >= spawnDelay && curLevelEnemiesNumber > 0)
            {
                spawnDelayPassed = 0;
                if(enemiesOnScreen <= maxEnemiesOnScreen)
                {
                    Spawn(1);
                }
            } else if(spawnDelayPassed < spawnDelay)
            {
                spawnDelayPassed += Time.deltaTime;
            }

        } else if(enemiesOnScreen == 0)
        {
            levelDelayPassed += Time.deltaTime;
            if(levelDelayPassed >= levelsDelay)
            {
                curLevelEnemiesNumber = 5;
            }
        }
    }

    void Spawn(int enemyType) 
    {
        GameObject newEnemy = Instantiate(enemies[enemyType]) as GameObject;
        newEnemy.transform.position = spawnPoint.transform.position;
        enemiesOnScreen += 1;
        curLevelEnemiesNumber -= 1;
        if(curLevelEnemiesNumber == 0)
        {
            levelDelayPassed = 0;
        }
    }

    public void removeEnemyFromScreen()
    {
        if(enemiesOnScreen > 0)
        {
            enemiesOnScreen -= 1;
        }
    }
}
