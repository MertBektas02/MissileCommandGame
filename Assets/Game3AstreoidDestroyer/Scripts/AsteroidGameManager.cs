using System;
using Unity.Mathematics;
using UnityEngine;


public class AsteroidGameManager :MonoBehaviour
{
    public int asteroidCount=0;
    private int level=0;


    [SerializeField] private Asteroid asteroidPrefab;

    private void Start()
    {
        StartLevel();
    }

    private void Update()
    {
        // if (asteroidCount==0)
        // {
        //     level++;
        //     int numAsteroids=2+(2*level);
        //     for (int i = 0; i < numAsteroids; i++)
        //     {
        //         SpawnAsteroid();
        //     }
        // }
    if (asteroidCount == 0)
    {
        StartLevel();
    }

      
    }
    private void StartLevel()
    {
        level++;
        int numAsteroids = 2 + (2 * level);
        for (int i = 0; i < numAsteroids; i++)
        {
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
         float offset=UnityEngine.Random.Range(0f,1f);
         Vector2 viewportSpawnPosition=Vector2.zero;
         int edge=UnityEngine.Random.Range(0,4);
         if (edge==0)
         {
            viewportSpawnPosition=new Vector2(offset,0);
         }
         else if (edge==1)
         {
            viewportSpawnPosition=new Vector2(offset,1);
         }
         else if (edge==2)
         {
            viewportSpawnPosition=new Vector2(0,offset);
         }
         else if (edge==3)
         {
            viewportSpawnPosition= new Vector2(1,offset);
         }
         Vector2 worldSpawnPosition=Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
         Asteroid  astroid=Instantiate(asteroidPrefab,worldSpawnPosition,quaternion.identity);
         astroid.gameManager=this;
         asteroidCount++;
    }
}
