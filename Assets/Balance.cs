using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Balance : MonoBehaviour
{
    // Start is called before the first frame update
    Treasury treasury;
    private int balance;
    [SerializeField] private TMP_Text _balance;
    
    // Update is called once per frame
    void Start()
    {
        treasury = Treasury.GetInstance();
    }
    void Update()
    {
        balance = treasury.Balance;
        _balance.text = balance.ToString();
    }
}
