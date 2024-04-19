using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle1 : MonoBehaviour, IInteractable
{
    [SerializeField]private GameObject wirePuzzle;
    public Transform interactorSource;
    [SerializeField] GameObject uiPromptButton;
    public float interactRange;

    public int level = 1;


    private void Start()
    {
        wirePuzzle.SetActive(false);
    }

    private void Update()
    {
        //IF RAY HITS UI SHOWS UP
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            uiPromptButton.SetActive(true);
        }
        else
        {
            uiPromptButton.SetActive(false);
        }
    }
  
    private void WirePuzzle()
    {
        wirePuzzle.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene("WirePuzzle");
    }

    public void SavePlayer()
    {
        SavePosition.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SavePosition.LoadPlayer();

        level = data.level;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
    }

    public void Interact()
    {
        WirePuzzle();
        SavePlayer();
    }
}
