using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    //public TreasuryDisplay treasuryDisplay;

    public float Points { get; private set; }
    public int PointsPerSecond { get; set; } = 1;
    // public TextMeshProUGUI PointsText;
    public Score score;
    private bool _hasEnded = false;

    public void EndGame() 
    {
      score.CurrScore = (int)Points;
      score.SetScore();
      _hasEnded = true;
    }
    void Start()
    {
      score = Score.GetInstance();
      Points = 0;
    }
    void FixedUpdate()
    {
      if(_hasEnded) return;
      UpdatePoints();
      UpdateText();
    }

    void UpdatePoints() 
    {
      Points += PointsPerSecond * Time.deltaTime;
    }

    void UpdateText() 
    {
      // PointsText.text = $"{(int)Points}";
    }

}