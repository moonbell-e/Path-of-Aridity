using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool _isNotPaused = true;
    public void PauseClicked()
    {
        Time.timeScale = 0f;
        Debug.Log(Time.timeScale);
    }

    public void ResumeClicked()
    {
        Time.timeScale = 1f;
        Debug.Log(Time.timeScale);
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
