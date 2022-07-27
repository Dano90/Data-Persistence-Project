using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBackToMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
