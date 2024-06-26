using UnityEngine.SceneManagement;
using UnityEngine;

public class StartingCutscene : MonoBehaviour
{
    [SerializeField] private GameObject cutscene1;
    [SerializeField] private GameObject Cam1;
    [SerializeField] private GameObject cutscene2;
    [SerializeField] private GameObject Cam2;
    [SerializeField] private GameObject cutscene3;
    [SerializeField] private GameObject Cam3;
    [SerializeField] private GameObject cutscene4;
    [SerializeField] private GameObject Cam4;
    [SerializeField] private GameObject cutscene5;
    [SerializeField] private GameObject Cam5;
    [SerializeField] private GameObject cutscene6;
    [SerializeField] private GameObject cam6;

    [SerializeField] private GameObject lighting1;
    [SerializeField] private GameObject lighting2;
    [SerializeField] private GameObject lighting3;

    private void Start()
    {
        cutscene1.SetActive(true);
        Cam1.SetActive(true);
        lighting1.SetActive(true);
    }
    public void Cutscene2()
    {
        cutscene1.SetActive(false);
        Cam1.SetActive(false);
        cutscene2.SetActive(true);
        Cam2.SetActive(true);
        lighting1.SetActive(false);
        lighting2.SetActive(true);
    }

    public void CutScene3()
    {
        cutscene2.SetActive(false);
        Cam2.SetActive(false);
        cutscene3.SetActive(true);
        Cam3.SetActive(true);
    }

    public void CutScene4()
    {
        cutscene3.SetActive(false);
        Cam3.SetActive(false);
        cutscene4.SetActive(true);
        Cam4.SetActive(true);
        lighting2.SetActive(false);
        lighting3.SetActive(true);
    }

    public void Cutscene5()
    {
        cutscene4.SetActive(false);
        Cam4.SetActive (false);
        cutscene5.SetActive(true);
        Cam5.SetActive(true);
    }

    public void Cutscene6()
    {
        cutscene5.SetActive(false);
        Cam5 .SetActive(false);
        cutscene6.SetActive(true);
        cam6 .SetActive(true);
    }

    public void Done()
    {
        SceneManager.LoadScene("Slums");
    }
}
