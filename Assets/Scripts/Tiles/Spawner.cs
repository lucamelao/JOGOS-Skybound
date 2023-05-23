using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tiles
{
  public class Spawner : MonoBehaviour
  {
      [SerializeField] private GameObject tile;
      [SerializeField] private int xPos;

      [SerializeField] private int yPos;
      //[SerializeField] private GameObject parent;
      void Start()
      {
        Instantiate(tile, new Vector3(xPos, yPos, 0), Quaternion.identity);
        //newTile.transform.position += tile.transform;
      }
  }
}