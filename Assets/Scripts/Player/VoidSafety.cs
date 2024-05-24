using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidSafety : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -10f)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        Invoke(nameof(ReloadLevel), .5f);
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
