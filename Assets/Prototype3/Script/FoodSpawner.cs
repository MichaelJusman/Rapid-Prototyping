using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : GameBehaviour
{
    public Transform[] foodSpawner;
    public GameObject[] foodType;

    public float foodSpeed;

    public float targetTime;

    public GameObject playerHead;

    public void Update()
    {

        if (_GSM.gameState == GameState.Playing)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0)
            {
                SpawnFood();
                targetTime = Random.Range(3, 6);
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
    }



}
