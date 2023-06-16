using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiles;
using Game.Player;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SeasonalTile _seasonalTile;
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _player;
    public int CurrDifficulty {get; private set;} = 1;
    private float _prevSpeed;
    private int accelerator = 1;
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
      if (_pointsManager.Points > accelerator) {
        _player.GetComponent<Rigidbody2D>().gravityScale += 0.2f;
        _player.GetComponent<PlayerStateMachine>().jumpForce += 17.5f;
        _spawner.Speed = _spawner.Speed + 0.25f;
        _spawner.ChangeMouleSpeed();
        accelerator++;
      }
      if (_pointsManager.Points > 20 * CurrDifficulty)
      {
        _seasonalTile.ChangeSeason();
        gameObject.GetComponent<Background>().ChangeSeason();
        CurrDifficulty++;
      }
    }

}