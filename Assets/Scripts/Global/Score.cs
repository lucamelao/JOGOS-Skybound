//import JsonUtility
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
public sealed class Score : SingletonBase<Score>
{
    public int CurrScore {get; set; }

    public int _highScore = 0;

    private string _dataPath = @"Assets/Resources/SaveData/score.json";


    public void SetScore()
    {
      if(CurrScore > _highScore) {
        _highScore = CurrScore;
        Save();
      }
      Destroy();
    }

    protected override void Init()
    {
      if(!File.Exists(_dataPath)) {
        Debug.Log("File does not exist");
        return;
      };
      var json = File.ReadAllText(_dataPath);
      ScoreData data = 
                JsonConvert.DeserializeObject<ScoreData>(json);
      _highScore = data.Score;
    }

    private void Save()
    {
      ScoreData data = new ScoreData();
      data.Score = _highScore;
      string json = JsonConvert.SerializeObject(data);
      File.WriteAllText(_dataPath, json);
    }


}