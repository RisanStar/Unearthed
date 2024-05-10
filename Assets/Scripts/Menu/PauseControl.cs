using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    //CANVAS
    [SerializeField] GameObject pauseMenu;
    //PAUSE KEY
    public KeyCode pauseKey = KeyCode.Escape;

    private void Start()
    {
        //MENU DOESN'T SHOW AT THE START OF THE GAME
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        //IF PAUSE KEY IS PRESSED PAUSE
        if (Input.GetKeyDown(pauseKey))
        {
            Pause();
        }
    }

    private void Pause()
    {
        //LOCK CURSOR WITHIN THE WINDOW AND MENU SHOWS WHILST GAME PAUSES
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
