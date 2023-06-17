//import JsonUtility
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
public sealed class Glider : SingletonBase<Glider>
{
    public bool[] GliderUnlocked {get; set; }

    private string _dataPath = "glider";

    protected override void Init()
    {
      GliderData data;
      if(!DataSaver.CheckPath(_dataPath)) {
        data = new GliderData();
        data.Unlocked = new bool[3];
        data.Unlocked[0] = true;
        data.Unlocked[1] = false;
        data.Unlocked[2] = false;
        DataSaver.SaveData(data, _dataPath);
      };

      data = DataSaver.LoadData<GliderData>(_dataPath);
      GliderUnlocked = data.Unlocked;
    }

    public void Save()
    {
      GliderData data = new GliderData();
      data.Unlocked = GliderUnlocked;
      DataSaver.SaveData(data, _dataPath);
        //File.WriteAllText(_dataPath, json);
    }


}