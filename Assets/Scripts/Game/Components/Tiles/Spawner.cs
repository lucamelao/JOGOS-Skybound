using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tiles
{
  public class Spawner : MonoBehaviour
  {
      [SerializeField] private List<GameObject> modules;

      [SerializeField] private SeasonalTile tile;
      [SerializeField] private int xPos;
      [SerializeField] private int yPos;

      [SerializeField] private int maxCapacity = 5;
      [SerializeField] private LevelManager levelManager;
      private Queue<GameObject> spawnedModules;

     
      //[SerializeField] private GameObject parent;
      void Start()
      {
        spawnedModules = new Queue<GameObject>(maxCapacity);
        for(int i = 0; i < maxCapacity; i++)
        {
          GameObject newTile = Instantiate(modules[0], new Vector3(xPos + i * 20, yPos, 0), Quaternion.identity);
          spawnedModules.Enqueue(newTile);
        }
        // Instantiate(modules[0], new Vector3(xPos, yPos, 0), Quaternion.identity);
        //newTile.transform.position += tile.transform;
      }

      void FixedUpdate()
      {
        checkNull();
        if(spawnedModules.Count < maxCapacity)
        {
          SpawnModule();
        }
      }

      void Update()
      {
        CheckSeason();
      }
      void checkNull()
      {
        if(spawnedModules.Peek() == null)
        {
          spawnedModules.Dequeue();
        }
      }

      void SpawnModule()
      {
        int index = GetSpawnIndex();
        Debug.Log($"Index: {index}");
        GameObject newTile = Instantiate(modules[index], new Vector3(xPos + spawnedModules.Count * 20, yPos, 0), Quaternion.identity);
        spawnedModules.Enqueue(newTile);
      }

      void CheckSeason() 
      {
        if (Input.GetKeyDown(KeyCode.R))
        {
         tile.ChangeSeason();
        }
      }

      int GetSpawnIndex()
      {
        return Random.Range(0, levelManager.CurrDifficulty);
      }
  }
}