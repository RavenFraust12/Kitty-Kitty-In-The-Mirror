using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [Header("In General")]
    public string nextScene;

    [Header("Gamescene")]
    public GameObject levelComplete;
    public StarRequirement requirement;

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelComplete.SetActive(true);
            requirement.FinishLevel();

            GameManager.instance.PauseGame();
        }
    }
}
