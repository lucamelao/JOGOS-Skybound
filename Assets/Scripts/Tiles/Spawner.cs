using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tiles
{
  public class Spawner : MonoBehaviour
  {
      [SerializeField] private List<GameObject> modules;
      [SerializeField] private int xPos;
      [SerializeField] private int yPos;

      [SerializeField] private int maxCapacity = 5;

      private float timePassed = 0.0f;
      private float timeToSpawn = 10.0f;
      private Queue<GameObject> spawnedModules;

     
      //[SerializeField] private GameObject parent;
      void Start()
      {
        spawnedModules = new Queue<GameObject>(maxCapacity);
        for(int i = 0; i < maxCapacity; i++)
        {
          GameObject newTile = Instantiate(modules[0], new Vector3(xPos + i * 20, yPos, 0), Quaternion.identity);
          Debug.Log("COUNT: " + spawnedModules.Count);
          spawnedModules.Enqueue(newTile);
        }
        // Instantiate(modules[0], new Vector3(xPos, yPos, 0), Quaternion.identity);
        //newTile.transform.position += tile.transform;
      }

      void FixedUpdate()
      {
        //check time passed
        //if time passed, spawn new module
        //if spawnedModules.Count > maxCapacity, destroy oldest module
        //if spawnedModules.Count < maxCapacity, spawn new module
        //if spawnedModules.Count == maxCapacity, do nothing
        //Debug.Log("COUNT: " + spawnedModules.Count);
        timePassed += Time.deltaTime;
        if(timePassed >= timeToSpawn)
        {
          SpawnModule();
          timePassed = 0.0f;
        }
      }

      void SpawnModule()
      {
        GameObject oldTile = spawnedModules.Dequeue();
         GameObject newTile = Instantiate(modules[0], new Vector3(xPos + spawnedModules.Count * 20, yPos, 0), Quaternion.identity);
        Destroy(oldTile);
        spawnedModules.Enqueue(newTile);
      }
  }
}