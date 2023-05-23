using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tiles
{
  public enum TileSeason
  {
    Land,
    Mountain,
    Sky
  }
  
  [CreateAssetMenu(fileName = "New Seasonal Tile", menuName = "Tiles/Seasonal Tile")]
  public class SeasonalTile : TileBase
  {
      public Sprite Land;
      public Sprite Mountain;
      public Sprite Sky;
      public TileSeason season;
      private Sprite newSprite;
    
      public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
      {
        base.GetTileData(location, tileMap, ref tileData);
        _RefreshMap();
        //    Change Sprite
        tileData.sprite = newSprite;
      }

      // public void RefreshSprite()
      // {
      //   _RefreshMap();
      //   Debug.Log("Refresh Sprite " + newSprite.name );
      //   sprite = newSprite;
      // }

      private void _RefreshMap()
      {
        switch (season)
        {
          case TileSeason.Mountain:
            newSprite = Mountain;
            break;
          case TileSeason.Sky:
            newSprite = Sky;
            break;
          default:
            newSprite = Land;
            break;
        }
      }
  }
}