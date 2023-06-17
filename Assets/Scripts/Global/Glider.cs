//import JsonUtility
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
public sealed class Glider : SingletonBase<Glider>
{
    public bool[] GliderUnlocked {get; set; }

    private string _dataPath = @"Assets/Resources/SaveData/glider.json";

    protected override void Init()
    {
      if(!File.Exists(_dataPath)) {
        Debug.Log("File does not exist");
        return;
      };
      var json = File.ReadAllText(_dataPath);
      GliderData data = 
                JsonConvert.DeserializeObject<GliderData>(json);
      GliderUnlocked = data.Unlocked;
    }

    public void Save()
    {
        GliderData data = new GliderData();
        data.Unlocked = GliderUnlocked;
        var json = JsonConvert.SerializeObject(data);
        File.WriteAllText(_dataPath, json);
    }


}