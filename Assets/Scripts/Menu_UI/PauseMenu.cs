using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject controlsMenuUI;
    public GameObject rightpanelMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            Cursor.lockState = CursorLockMode.None;
            if (gameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ControlsMenu()
    {
        ReturnMenu(controlsMenuUI, rightpanelMenuUI);

    }

    public void ConrtolToReturn()
    {
        ReturnMenu(rightpanelMenuUI, controlsMenuUI);
    }

    void ReturnMenu(GameObject objToActive, GameObject objToDeactive)
    {
        objToActive.SetActive(true);
        objToDeactive.SetActive(false);
    }
}
