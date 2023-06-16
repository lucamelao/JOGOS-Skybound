using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiles;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SeasonalTile _seasonalTile;
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private Spawner _spawner;
    public int CurrDifficulty {get; private set;} = 1;
    private float _prevSpeed;
    public void EndGame() 
    {
      _pointsManager.EndGame();
    }

    public void SetStop() 
    {
      _prevSpeed = _spawner.Speed;
      _spawner.Speed = 0f;
      _spawner.ChangeMouleSpeed();
    }
    public void SetContinue() 
    {
      _spawner.Speed = _prevSpeed;
      _spawner.ChangeMouleSpeed();
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
        _spawner.Speed = _spawner.Speed + 10f;
        _spawner.ChangeMouleSpeed();
        _seasonalTile.ChangeSeason();
        CurrDifficulty++;
      }
    }

}