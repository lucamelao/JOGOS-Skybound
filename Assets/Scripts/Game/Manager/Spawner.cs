using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Modules;
using Tiles;

public class Spawner : MonoBehaviour, IsManager
{
    [SerializeField] private List<GameObject> modules;

    [SerializeField] private SeasonalTile tile;
    [SerializeField] private int xPos;
    [SerializeField] private int yPos;

    [SerializeField] private int maxCapacity = 5;
    [SerializeField] private LevelManager levelManager;
    private Queue<GameObject> spawnedModules;
    private int lastIndex = 0;

    public float Speed { get; set; } = 5f;
    
    //[SerializeField] private GameObject parent;

    void Start()
    {
      spawnedModules = new Queue<GameObject>(maxCapacity);
      GameObject newTile = Instantiate(modules[9], new Vector3(xPos, yPos, 0), Quaternion.identity);
      newTile.GetComponent<Module>().Speed = Speed;
      spawnedModules.Enqueue(newTile);
      for(int i = 1; i < maxCapacity; i++)
      {
        newTile = Instantiate(modules[GetSpawnIndex()], new Vector3(xPos + i * 25, yPos, 0), Quaternion.identity);
        newTile.GetComponent<Module>().Speed = Speed;
        spawnedModules.Enqueue(newTile);
      }
    }

    public void EndGame()
    {
      foreach(GameObject module in spawnedModules)
      {
        Destroy(module);
      }
    }

    public void ChangeMouleSpeed()
    {
      foreach(GameObject module in spawnedModules)
      {
        module.GetComponent<Module>().Speed = Speed;
      }
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
      GameObject newTile = Instantiate(modules[GetSpawnIndex()], new Vector3(xPos + spawnedModules.Count * 26, yPos, 0), Quaternion.identity);
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
      int index = lastIndex, random = Random.Range(0, 99);
      while (index == lastIndex)
      {
        random = Random.Range(0, 99);
        switch (levelManager.CurrDifficulty)
        {
          case 1:
            index = random/33;
            break;
          case 2:
            if (random < 33) {index = random/11;}
            else {index = 3+(random-33)/22;}
            break;
          default:
            if (random < 18) {index = random/6;}
            else if (random < 48) {index = 3+(random-18)/10;}
            else {index = 6+(random-48)/17;}
            break;
        }
      }
      lastIndex = index;
      return index;
    }
}