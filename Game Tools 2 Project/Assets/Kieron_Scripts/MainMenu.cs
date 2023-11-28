using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ui;

    public void PlayGame()
    {
        SceneManager.LoadScene("KieronMazeScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ContinueGame()
    {
        gameObject.SetActive(false);
    }
}
