using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tiles
{
  public class TilemapRefresh : MonoBehaviour
  {
      public Tilemap tilemap;
  
      void Start()
      {
        tilemap = GetComponent<Tilemap>();
      }

      void FixedUpdate()
      {
        tilemap.RefreshAllTiles();
        Move();
      }

      private void Move()
      {
        transform.Translate(-transform.right * Time.deltaTime * 2.0f);
      }
  }
}