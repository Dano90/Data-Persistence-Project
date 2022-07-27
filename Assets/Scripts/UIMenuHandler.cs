using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif 

public class UIMenuHandler : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI bestScoreText;
    public void Start()
    {
        if (DataManager.Instance.bestScore != 0)
        {
            bestScoreText.text = $"Best Score : {DataManager.Instance.bestScoreName} : {DataManager.Instance.bestScore}";
        }
    }
    public void StartGame()
    {
        DataManager.Instance.playerNameText = playerName.text;
        SceneManager.LoadScene(1);
    }
    public void GoToScoreTables()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        DataManager.Instance.SaveBestScore();
    }

}
