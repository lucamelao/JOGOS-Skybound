using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiles;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SeasonalTile _seasonalTile;
    [SerializeField] private PointsManager _pointsManager;
    public int CurrDifficulty {get; private set;} = 1;
    public void EndGame() 
    {
      _pointsManager.EndGame();
    }
    void Start()
    {
      _seasonalTile.Init();
    }
    void FixedUpdate()
    {
      CheckDifficulty();
    }

    void CheckDifficulty()
    {
      if(_seasonalTile.season == TileSeason.Sky) return;
      if (_pointsManager.Points > 10 * CurrDifficulty)
      {
        _seasonalTile.ChangeSeason();
        CurrDifficulty++;
      }
    }

}