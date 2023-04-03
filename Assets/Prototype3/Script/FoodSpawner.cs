using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : GameBehaviour<FoodSpawner>
{
    public Transform[] foodSpawner;
    public GameObject[] foodType;

    public float foodSpeed;

    public float targetTime;

    public int minimumTime = 3;
    public int maximumTime = 6;
    public int increaseSpeed = 100;
    public int spawnCounter = 0;
    public int projectileSpeed = 100;

    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;
    public bool level4 = false;
    public bool level5 = false;

    public GameObject playerHead;
    public void Start()
    {
        level1 = true;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
    }

    public void Update()
    {

        if(spawnCounter == 5 && level1)
        {
            projectileSpeed += increaseSpeed;
            level1 = false;
            level2 = true;
        }

        if (spawnCounter == 10 && level2)
        {
            projectileSpeed += increaseSpeed;
            level2 = false;
            level3 = true;
        }

        if (spawnCounter == 15 && level3)
        {
            projectileSpeed += increaseSpeed;
            level3 = false;
            level4 = true;
        }

        if (spawnCounter == 20 && level4)
        {
            projectileSpeed += increaseSpeed;
            level4 = false;
            level5 = true;
        }

        if (spawnCounter == 25 && level5)
        {
            projectileSpeed += increaseSpeed;
            level5 = false;
        }


        if (_GSM.gameState == GameState.Playing)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0)
            {
                SpawnFood();
                targetTime = Random.Range(minimumTime, maximumTime);
                spawnCounter++;
            }
        }
        else
            return;

        
        

        //int randomTime = Random.Range(1, 4);
        //ExecuteAfterSeconds(randomTime, () => SpawnFood());
    }

    void SpawnFood()
    {
        Instantiate(foodType[Random.Range(0, foodType.Length)], foodSpawner[Random.Range(0, foodSpawner.Length)].position, foodSpawner[Random.Range(0, foodSpawner.Length)].rotation);
        //breadInstantiate.GetComponent<Rigidbody>().AddForce((playerHead.transform.position - foodSpawner[Random.Range(0, foodSpawner.Length)].position) * foodSpeed);
        projectileSpeed += increaseSpeed;
    }



}
