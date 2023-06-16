using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    //public TreasuryDisplay treasuryDisplay;

    public float Points { get; private set; }
    public int PointsPerSecond { get; set; }
    public Treasury treasury;

    public void EndGame() 
    {
      treasury.Receive((int)Points);
      treasury.Save();
      Points = 0;
    }
    void Start()
    {
      treasury = Treasury.GetInstance();
      Points = 0;
      PointsPerSecond = 1;
    }
    void FixedUpdate()
    {
      UpdatePoints();
    }

    void UpdatePoints() 
    {
      Points += PointsPerSecond * Time.deltaTime;
    }

}