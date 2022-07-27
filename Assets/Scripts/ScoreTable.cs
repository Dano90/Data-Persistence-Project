using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTable : MonoBehaviour
{
    public TextMeshProUGUI firstPlaceText;
    public TextMeshProUGUI secondPlaceText;
    public TextMeshProUGUI thirdPlaceText;

    void Start()
    {
        firstPlaceText.text = $"{DataManager.Instance.bestScoreName} : {DataManager.Instance.bestScore}";
        secondPlaceText.text = $"{DataManager.Instance.secondBestScoreName} : {DataManager.Instance.secondBestScore}";
        thirdPlaceText.text = $"{DataManager.Instance.thirdBestScoreName} : {DataManager.Instance.thirdBestScore}";
    }
}
