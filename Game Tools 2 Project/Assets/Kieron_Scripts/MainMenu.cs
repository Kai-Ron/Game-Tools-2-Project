using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject options;
    public GameObject Pause;
    private bool IsPaused = false;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && IsPaused == false)
        {
           IsPaused = true;          
           Pause.SetActive(true);
           Debug.Log("Paused");
           
        }
       
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ContinueGame()
    {
        options.SetActive(false);
    }
}
