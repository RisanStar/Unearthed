using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject playBtn;
    [SerializeField] private GameObject quitBtn;
    [SerializeField] private GameObject ctrlBtn;
    [SerializeField] private GameObject backctrlbtn;
    [SerializeField] private GameObject credbtn;
    [SerializeField] private GameObject backcredbtn;

    public void Play()
    {
        SceneManager.LoadScene("Slums");
    }

    public void Controls()
    {
        playBtn.SetActive(false);
        quitBtn.SetActive(false);
        ctrlBtn.SetActive(false);
        backcredbtn.SetActive(false);
        credbtn.SetActive(false);
        backctrlbtn.SetActive(true);
    }

    public void Credits()
    {
        playBtn.SetActive(false);
        quitBtn.SetActive(false);
        credbtn.SetActive(false);
        backctrlbtn.SetActive(false);
        ctrlBtn.SetActive(false);
        backcredbtn.SetActive(true);
    }

    public void Back()
    {
        playBtn.SetActive(true);
        quitBtn.SetActive(true);
        credbtn.SetActive(true);
        ctrlBtn.SetActive(true);
        backctrlbtn.SetActive(false);
        backcredbtn.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
