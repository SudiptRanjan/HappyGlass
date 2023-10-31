using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class HighestPercetageData
{
    public float highScore;
}

public class HighestPercetage : MonoBehaviour
{

    #region PUBLIC_VARS
    #endregion
    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS

    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion
    public static HighestPercetage instance;
    public TextMeshProUGUI highScoreTextForGameOver;

    private float highScore = 0;
    private const string highScoreFilePath = "/highscore.json";

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadHighScore();
        UpdateHighScoreText();
    }
    public void UpdateHighScore(float score)
    {
        if (score < highScore)
        {
            highScore = score;
            SaveHighScore();
        }

        UpdateHighScoreText();
    }


    private void SaveHighScore()
    {
        string path = Application.persistentDataPath + highScoreFilePath;
        HighestPercetageData data = new HighestPercetageData();
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    private void LoadHighScore()
    {
        string path = Application.persistentDataPath + highScoreFilePath;

        //print(path);
        //Debug.Log(path + " Path of saved file");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighestPercetageData data = JsonUtility.FromJson<HighestPercetageData>(json);
            highScore = data.highScore;
        }
    }


    private void UpdateHighScoreText()
    {
        highScoreTextForGameOver.text = "High %: " + highScore.ToString();
    }
}


