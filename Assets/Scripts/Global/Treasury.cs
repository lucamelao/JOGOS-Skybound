//import JsonUtility
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
public sealed class Treasury : SingletonBase<Treasury>
{
    public int Balance {get; private set; }= 100;

    private string _dataPath = @"Assets/Resources/SaveData/treasury.json";


    public void Receive(int amount)
    {
      Balance += amount;
    }

    public bool Spend(int amount)
    {
      if(amount > Balance) return false;
      Balance += amount;
      return true;
    }

    protected override void Init()
    {
      //log curr directory
      // string[] filePaths = Directory.GetFiles(_dataPath);
      // foreach (string filePath in filePaths)
      // {
      //   Debug.Log(filePath);
      // }
      if(!File.Exists(_dataPath)) {
        Debug.Log("File does not exist");
        return;
      };
      var json = File.ReadAllText(_dataPath);
      TreasuryData data = 
                JsonConvert.DeserializeObject<TreasuryData>(json);
      Balance = data.Balance;
    }

    public void Save()
    {
      TreasuryData data = new TreasuryData();
      data.Balance = Balance;
      string json = JsonConvert.SerializeObject(data);
      File.WriteAllText(_dataPath, json);
      Destroy();
    }


}