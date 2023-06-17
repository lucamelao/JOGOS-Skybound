using System;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
public class DataSaver
{
    //Save Data
    public static void SaveData<T>(T dataToSave, string dataFileName)
    {
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        //Convert To Json then to bytes
        var json = JsonConvert.SerializeObject(dataToSave);
        byte[] jsonByte = Encoding.ASCII.GetBytes(json);


        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        }
        //Debug.Log(path);

        try
        {
            File.WriteAllBytes(tempPath, jsonByte);
        }
        catch (Exception e)
        {
        }
    }

    //Load Data
    public static T LoadData<T>(string dataFileName)
    {
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        //Exit if Directory or File does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            return default(T);
        }

        if (!File.Exists(tempPath))
        {
            return default(T);
        }

        //Load saved Json
        byte[] jsonByte = null;
        try
        {
            jsonByte = File.ReadAllBytes(tempPath);
        }
        catch (Exception e)
        {
        }

        //Convert to json string
        string jsonData = Encoding.ASCII.GetString(jsonByte);

        //Convert to Object
        object data = JsonConvert.DeserializeObject<T>(jsonData);
        return (T)Convert.ChangeType(data, typeof(T));
    }

    public static bool DeleteData(string dataFileName)
    {
        bool success = false;

        //Load Data
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        //Exit if Directory or File does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            return false;
        }

        if (!File.Exists(tempPath))
        {
            return false;
        }

        try
        {
            File.Delete(tempPath);
            success = true;
        }
        catch (Exception e)
        {
        }

        return success;
    }

    public static bool CheckPath(string dataFileName)
    {
      string tempPath = Path.Combine(Application.persistentDataPath, "data");
      tempPath = Path.Combine(tempPath, dataFileName + ".txt");
      if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
      {
          return false;
      }

      if (!File.Exists(tempPath))
      {
          return false;
      }
      return true;
    }
}