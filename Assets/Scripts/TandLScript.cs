using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TandLScript : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float timeRemaining = 300f; // 5 minutes
    private bool timerRunning = true;

    [Header("UI Reference")]
    public TextMeshProUGUI timerText;

    [Header("Lose Screen UI")]
    public GameObject loseScreenUI;
    public Button restartButton;
    public Button quitButton;

    [SerializeField] AudioSource shotAudio;
    [SerializeField] AudioClip shotClip;

    public bool playerLose;
    private void Start()
    {
        // Start with lose screen hidden
        if (loseScreenUI != null)
        {
            loseScreenUI.SetActive(false);
        }
            

        // Unpause in case the game was paused before
        Time.timeScale = 1f;

        playerLose = false;
    }

    void Update()
    {
        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI(timeRemaining);

            if (timeRemaining <= 0)
            {
                timerRunning = false;
                Debug.Log("Time's up! Level failed.");
                shotAudio.PlayOneShot(shotClip);
                HandleLevelFailure();
                playerLose = true;
            }
        }
    }

    void UpdateTimerUI(float time)
    {
        time = Mathf.Max(0, time);
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("Time Left: " + "{0:00}:{1:00}", minutes, seconds);
    }

    private void HandleLevelFailure()
    {
        Time.timeScale = 0f;
        loseScreenUI.SetActive(true);

        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartLevel);

        quitButton.onClick.RemoveAllListeners();
        quitButton.onClick.AddListener(QuitGame);
    }

    private void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    private void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
