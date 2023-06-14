using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TreasuryManager : MonoBehaviour
{
    public Treasury treasury;
    //public TreasuryDisplay treasuryDisplay;
    void Start()
    {
      treasury = Treasury.GetInstance();
      Debug.Log($"Treasury INIT: {treasury.Balance}");

      treasury.Receive(12);
      treasury.Save();

       // treasuryDisplay = FindObjectOfType<TreasuryDisplay>();
    }
    void Update()
    {
       // treasuryDisplay.UpdateDisplay(treasuryData.Balance);
    }
}