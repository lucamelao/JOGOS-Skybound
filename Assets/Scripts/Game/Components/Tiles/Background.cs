using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tiles
{
  public class Background : MonoBehaviour
  {
      [SerializeField] private SeasonalTile tile;
      public GameObject landBg;
      public GameObject mountainBg;
      public GameObject skyBg;

      public void ChangeSeason()
      {
        switch (tile.season)
          {
            case TileSeason.Mountain:
              landBg.SetActive(false);
              mountainBg.SetActive(true);
              skyBg.SetActive(false);
              break;
            case TileSeason.Sky:
              landBg.SetActive(false);
              mountainBg.SetActive(false);
              skyBg.SetActive(true);
              break;
            default:
              landBg.SetActive(true);
              mountainBg.SetActive(false);
              skyBg.SetActive(false);
              break;
          }
      }
  }
}