using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseManager : MonoBehaviour
{
    public static event Action OnPauseClicked;

    public void PauseClicked()
    {
        OnPauseClicked?.Invoke();
        Time.timeScale = 0f;
    }

    public void ResumeClicked()
    {
        Time.timeScale = 1f;
    }


    public void GoToMainMenu()
    {
        //PlayerPrefs.SetInt("NewGameStarted", 1);
        SceneManager.LoadScene("Menu");
    }
}
