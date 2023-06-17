//import JsonUtility
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
public sealed class Score : SingletonBase<Score>
{
    public int CurrScore {get; set; }

    public int _highScore = 0;

    private string _dataPath = "score";


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
      ScoreData data;
      if(!DataSaver.CheckPath(_dataPath)) {
        data = new ScoreData();
        data.Score = 0;
        DataSaver.SaveData(data, _dataPath);
      };

      data = DataSaver.LoadData<ScoreData>(_dataPath);
      _highScore = data.Score;
    }

    private void Save()
    {
      ScoreData data = new ScoreData();
      data.Score = _highScore;
      DataSaver.SaveData(data, _dataPath);
      //File.WriteAllText(_dataPath, json);
    }


}