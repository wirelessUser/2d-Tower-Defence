using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameControlller : MonoBehaviour
{
    public static MainGameControlller instance;

    public int  enemySpawnCount;

    public GameObject[] enemyPrefbas;

    public float spawnAfterTime;

    public Transform spawnPos;
    public int enemyOnGame, maxEnemyCanSpawn;
    public int CoinInTreasure;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnAfterTime);

        for (int i = 0; i < enemyPrefbas.Length; i++)
        {
            for (int j = 0; j < enemySpawnCount; j++)
            {
                if (enemyOnGame<maxEnemyCanSpawn)
                {
                    GameObject enemyInstantiate = Instantiate(enemyPrefbas[i]);
                    enemyInstantiate.transform.position = spawnPos.position;
                    enemyOnGame++;
                    yield return new WaitForSeconds(spawnAfterTime);
                }
               
            }
           

        }

       
        StartCoroutine(SpawnEnemies());

    }
}
