using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public enum GameState
{
    GameStart,
    GameStop
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState;

    public GameObject optionsPanel;
    public bool isOptionOn;

    void Awake() => instance = this;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenOptions();
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    public void OpenOptions()
    {
        if (optionsPanel != null)
        {
            if (!isOptionOn)
            {
                isOptionOn = true;
                optionsPanel.SetActive(true);
                PauseGame();
            }
            else
            {
                isOptionOn = false;
                optionsPanel.SetActive(false);
                StartGame();
            }
        }
    }

    public void PauseGame()
    {
        gameState = GameState.GameStop;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        gameState = GameState.GameStart;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
