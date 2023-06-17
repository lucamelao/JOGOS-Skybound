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
    public SpriteRenderer spriteRenderer;
    public Sprite[] gliders;
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
      spriteRenderer.sprite = gliders[PlayerPrefs.GetInt("selectedGlider")]; 
      _seasonalTile.Init();
    }
    void FixedUpdate()
    {
      CheckDifficulty();
    }

    void CheckDifficulty()
    {
      if(accelerator == 60) return;
      if (_pointsManager.Points > accelerator) {
        _player.GetComponent<Rigidbody2D>().gravityScale += 0.8f/6f;
        _player.GetComponent<PlayerStateMachine>().jumpForce += 35.1f/3f;
        _spawner.Speed = _spawner.Speed + 1f/6f;
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