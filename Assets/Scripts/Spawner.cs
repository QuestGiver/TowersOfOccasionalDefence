using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 20;
    [SerializeField]
    public GameObject[] enemies;
    public int waveSize = 5;
    public int livingEnemies;
    float timer;
    bool canSpawn = false;
    float waveSpawnRate = 0.5f;
    float waveSpawnTimer;
    int counter = 0;

    // Use this for initialization
    void Start()
    {
        timer = spawnRate;
        waveSpawnTimer = waveSpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        waveSpawnTimer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            if (livingEnemies == 0)
            {

                canSpawn = true;
                waveSize++;
                timer = 0;
            }
        }


        if (canSpawn)
        {
            if (waveSpawnTimer >= waveSpawnRate)
            {
                if (counter < waveSize)
                {
                    Instantiate(enemies[0], new Vector3(35 + Random.Range(-counter, counter), 2, 0 + Random.Range(-counter, counter)), new Quaternion(0, 0, 0, 0));
                    livingEnemies++;
                    counter++;
                    waveSpawnTimer = 0;
                }
                else
                {
                    canSpawn = false;
                    counter = 0;
                }
            }
        }

    }


}
