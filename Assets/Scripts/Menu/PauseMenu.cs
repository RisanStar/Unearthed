using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Resume()
    {
        //UNPAUSES THE GAME
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home()
    {
        //GO TO THE HOME SCREEN
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
