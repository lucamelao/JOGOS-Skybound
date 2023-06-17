using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiles;
using Game.Player;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SeasonalTile _seasonalTile;
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _player;
    public TextMeshProUGUI CoinsText;
    public int CurrDifficulty {get; private set;} = 1;
    private float _prevSpeed;
    private int accelerator = 1;
    
    public SpriteRenderer spriteRenderer;
    public Sprite[] gliders;
    private Treasury treasury;

    private bool isStopped = false;
    public void EndGame() 
    {
      _pointsManager.EndGame();
      SceneManager.LoadScene("StartMenu");
      treasury.Save();
    }

    public void SetStop() 
    {
      isStopped = true;
      _prevSpeed = _spawner.Speed;
      _spawner.Speed = 0f;
      _spawner.ChangeMouleSpeed();
      _pointsManager.SetStop();
    }
    public void SetContinue() 
    {
      isStopped = false;
      _spawner.Speed = _prevSpeed;
      _spawner.ChangeMouleSpeed();
      _pointsManager.SetContinue();
    }
    void Start()
    {
      treasury = Treasury.GetInstance();
      spriteRenderer.sprite = gliders[PlayerPrefs.GetInt("selectedGlider")]; 
      _player.GetComponent<PlayerStateMachine>().airForceConstant = PlayerPrefs.GetInt("selectedGlider")*8 + 2;
      _seasonalTile.Init();
    }
    void FixedUpdate()
    {
      CheckDifficulty();
      CoinsText.text = $"{treasury.Balance}";
    }

    void CheckDifficulty()
    {
      if(isStopped) return;
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
        treasury.Receive(10);
      }
    }

}