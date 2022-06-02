using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{

    public GameObject powerUp;
    public GameObject obj;
    float spawnPosX;
    float spawnPosZ;
    private float randomBound = 9f;
    Vector3 spawnPos;
    int passingValue = 1;
    int enemyCount;
    void Start()
    {
         Instantiate(powerUp, GenarateRandomposition(), powerUp.transform.rotation); 

        EnemySpawn(passingValue);

    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
      if(enemyCount == 0)

        {

            Instantiate(powerUp, GenarateRandomposition(), powerUp.transform.rotation);
 
            passingValue++;
            EnemySpawn(passingValue);

        }
    }

    public void EnemySpawn(int x)
    {
       

        for (int i = 0; i < x; i++)
        {
          Instantiate(obj, GenarateRandomposition(), obj.transform.rotation);
        }
    }
   Vector3 GenarateRandomposition()
    {

        spawnPosX = Random.Range(-randomBound, randomBound);
        spawnPosZ = Random.Range(-randomBound, randomBound);
         spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
    

}
