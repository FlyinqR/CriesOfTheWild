using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;   // Import Scene Management
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    public bool HoldingItem;
    private int activatedPressurePlates = 0; // Track activated plates
    public int totalItems = 5; // Set this based on the number of items
    private int itemsCollected = 0; // Track collected items
    public Material boxColor;
    public Material PressurePlateColor;
    [Header("Timer Settings")] // ADD >>>
    [SerializeField] private float timeRemaining = 300f; // 5 minutes
    private bool timerRunning = true;
    [Header("UI Reference")] // ADD >>>
    public TextMeshProUGUI timerText;
    [Header("Lose Screen UI")] // ADD >>>
    public GameObject loseScreenUI;
    public Button restartButton;
    public Button quitButton;

    void Update()
    {
        if (timerRunning) // ADD >>>
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI(timeRemaining);

            if (timeRemaining <= 0)
            {
                timerRunning = false;
                Debug.Log("Time's up! Level failed.");
                HandleLevelFailure(); // Restart level or custom fail logic
            }
        }
    }


    private void HandleLevelFailure()
    {
        timerRunning = false;
        loseScreenUI.SetActive(true); // Show lose screen
        Time.timeScale = 0f; // Pause the game

        restartButton.onClick.RemoveAllListeners(); // Just to be safe
        restartButton.onClick.AddListener(RestartLevel);

        quitButton.onClick.RemoveAllListeners();
        quitButton.onClick.AddListener(QuitGame);
    }



    private void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("Game Quit");
    }

    void UpdateTimerUI(float time) // ADD >>>
    {
        time = Mathf.Max(0, time);
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable" && !HoldingItem && Input.GetMouseButton(1))
        {
            HoldingItem = true;
            itemsCollected++; // Increase collected item count
            Debug.Log("Item Collected: " + itemsCollected);
            boxColor = collision.gameObject.GetComponent<MeshRenderer>().materials[0];
            Debug.Log(boxColor);
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "PressurePlate" && HoldingItem && Input.GetMouseButton(1))
        {
            PressurePlateColor = collision.gameObject.GetComponent<MeshRenderer>().materials[0];
            Debug.Log(PressurePlateColor);
            if (PressurePlateColor.name == boxColor.name)
            {
                Debug.Log("Item Dropped");
                
                activatedPressurePlates++; // Increase activated plate count
                Debug.Log("Pressure Plate Activated: " + activatedPressurePlates);
                collision.gameObject.SetActive(false);

                CheckLevelCompletion(); // Check if all plates are activated
                HoldingItem = false;
            }
            else
            {
                Debug.Log("Wrong Piece");
                //Debug.Log("Plate color is " + PressurePlateColor);
                //Debug.Log("Box color is " + boxColor);
            }
           
        }
    }

    private void CheckLevelCompletion()
    {
        if (activatedPressurePlates >= totalItems)
        {
            Debug.Log("Level Complete! Loading Next Level...");
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1; // Get next scene index
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) // Check if next scene exists
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels available!");
        }
    }

    
}
