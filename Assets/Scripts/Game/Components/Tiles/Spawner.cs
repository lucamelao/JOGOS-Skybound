using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Modules;

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

      public float Speed { get; set; } = 5f;
     
      //[SerializeField] private GameObject parent;

      public void ChangeMouleSpeed()
      {
        foreach(GameObject module in spawnedModules)
        {
          module.GetComponent<Module>().Speed = Speed;
        }
      }
      void Start()
      {
        spawnedModules = new Queue<GameObject>(maxCapacity);
        for(int i = 0; i < maxCapacity; i++)
        {
          GameObject newTile = Instantiate(modules[0], new Vector3(xPos + i * 25, yPos, 0), Quaternion.identity);
          newTile.GetComponent<Module>().Speed = Speed;
          spawnedModules.Enqueue(newTile);
        }
        // Instantiate(modules[0], new Vector3(xPos, yPos, 0), Quaternion.identity);
        //newTile.transform.position += tile.transform;
      }

      void FixedUpdate()
      {
      }

      void Update()
      {
        checkNull();
        if(spawnedModules.Count < maxCapacity)
        {
          SpawnModule();
        }
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
        GameObject newTile = Instantiate(modules[index], new Vector3(xPos + spawnedModules.Count * 25, yPos, 0), Quaternion.identity);
        newTile.GetComponent<Module>().Speed = Speed;
        spawnedModules.Enqueue(newTile);
      }

      void CheckSeason() 
      {
        if (Input.GetKeyDown(KeyCode.R))
        {
         tile.ChangeSeason();
         gameObject.GetComponent<Background>().ChangeSeason();
        }
      }

      int GetSpawnIndex()
      {
        return Random.Range(0, levelManager.CurrDifficulty);
      }
  }
}