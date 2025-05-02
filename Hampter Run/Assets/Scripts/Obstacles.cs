using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    public string restartScene;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(restartScene);
        }
    }
}
