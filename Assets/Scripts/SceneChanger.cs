using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject charMenu;
    public GameObject pauseMenu;
    public GameObject sureMenu;
    public victoryDetector vdet;
    public PlayerOneStats p1st;
    public PlayerTwoStats p2st;
    bool isPaused = false;

    void Start()
    {
        charMenu.SetActive(false);
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        sureMenu.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ClosePauseMenu();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }

    public void PlayButton()
    {
        if (p1st.id != 0 && p2st.id != 0)
        {
            SceneManager.LoadScene("Arena");
        }
    }

    public void OpenCharSelect()
    {
        charMenu.SetActive(true);
    }

    public void closeCharSelect()
    {
        charMenu.SetActive(false);
    }

    public void ControlsButton()
    {
        controlsMenu.SetActive(true);
    }

    public void CloseControls()
    {
        controlsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        vdet.gameRunning = false;
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        vdet.gameRunning = true;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NoButton()
    {
        sureMenu.SetActive(false);
    }

    public void OpenSure()
    {
        sureMenu.SetActive(true);
    }
}
