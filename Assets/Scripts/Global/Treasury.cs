//import JsonUtility
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
public sealed class Treasury : SingletonBase<Treasury>
{
    public int Balance {get; private set; }= 100;

    private string _dataPath = "treasury";


    public void Receive(int amount)
    {
      Balance += amount;
    }

    public bool Spend(int amount)
    {
      if(amount > Balance) return false;
      Balance -= amount;
      return true;
    }

    protected override void Init()
    {
      TreasuryData data;
      if(!DataSaver.CheckPath(_dataPath)) {
        data = new TreasuryData();
        data.Balance = 0;
        DataSaver.SaveData(data, _dataPath);
      };

      data = DataSaver.LoadData<TreasuryData>(_dataPath);
      Balance = data.Balance;
    }

    public void Save()
    {
      TreasuryData data = new TreasuryData();
      data.Balance = Balance;
      DataSaver.SaveData(data, _dataPath);
      Destroy();
    }


}