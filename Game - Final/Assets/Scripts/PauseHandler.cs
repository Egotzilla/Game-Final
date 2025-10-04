using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseHandler : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseCanvas;
    public Button resumeButton;
    public Button reStartButton;
    public Button mainMenuButton;

    private bool isPaused = false;

    void Start()
    {
        // Make sure pause canvas is initially hidden
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);
        else
            Debug.LogWarning("pauseCanvas is not assigned!");

        // Set up button listeners
        if (resumeButton != null)
            resumeButton.onClick.AddListener(ResumeGame);
        
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(GoToMainMenu);

        if (reStartButton != null)
            reStartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        // Check for ESC key press (works with both old and new input systems)
        if (Input.GetKeyDown(KeyCode.Escape) || Input.inputString.Contains("\u001b"))
        {
            Debug.Log("ESC key pressed!"); // Debug log to confirm key detection
            
            if (isPaused)
            {
                Debug.Log("Game is paused, resuming...");
                ResumeGame();
            }
            else
            {
                Debug.Log("Game is running, pausing...");
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Stop the game
        
        if (pauseCanvas != null)
            pauseCanvas.SetActive(true);
            
        // Show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);
            
        // Hide cursor (adjust based on your game needs)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        Debug.Log("Game Resumed");
    }

    public void GoToMainMenu()
    {
        Debug.Log("Returning to Main Menu from Pause Menu");
        Time.timeScale = 1f; // Make sure time scale is reset
        SceneManager.LoadScene("MainMenu"); // Load main menu scene
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Make sure time scale is reset
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart current scene
        Debug.Log("Game Restarted from Pause Menu");
    }
}
