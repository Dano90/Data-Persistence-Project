using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
   
    public string playerNameText;
    public int bestScore = 0;
    public int secondBestScore = 0;
    public int thirdBestScore = 0;
    public string bestScoreName;
    public string secondBestScoreName;
    public string thirdBestScoreName;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore; 
        public int secondBestScore;
        public int thirdBestScore;
        public string bestScoreName;
        public string secondBestScoreName;
        public string thirdBestScoreName;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.secondBestScore = secondBestScore;
        data.thirdBestScore = thirdBestScore;
        data.bestScoreName = bestScoreName;
        data.secondBestScoreName = secondBestScoreName;
        data.thirdBestScoreName = thirdBestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/Savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            secondBestScore = data.secondBestScore;
            thirdBestScore = data.thirdBestScore;
            bestScoreName = data.bestScoreName;
            secondBestScoreName = data.secondBestScoreName;
            thirdBestScoreName = data.thirdBestScoreName;
        }
    }
    public void SettingHighscore(int score)
    {
        if (score > bestScore)
        {
            thirdBestScore = secondBestScore;
            thirdBestScoreName = secondBestScoreName;
            secondBestScore = bestScore;
            secondBestScoreName = bestScoreName;

            bestScore = score;
            bestScoreName = playerNameText;
        }
        else if (score > secondBestScore)
        {
            thirdBestScore = secondBestScore;
            thirdBestScoreName = secondBestScoreName;

            secondBestScore = score;
            secondBestScoreName = playerNameText;
        }
        else if (score > thirdBestScore)
        {
            thirdBestScore = score;
            thirdBestScoreName = playerNameText;
        }
    }
}
