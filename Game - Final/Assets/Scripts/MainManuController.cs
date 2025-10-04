using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuController : MonoBehaviour
{
    public Button madDriverButton;
    public Button flyLikeABirdButton;
    public Button imSumoButton;
    public Button exitButton;

    private void Start()
    {
        madDriverButton.onClick.AddListener(StartPrototype1);
        flyLikeABirdButton.onClick.AddListener(StartChallenge3);
        imSumoButton.onClick.AddListener(StartPrototype4);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void StartPrototype1()
    {
        SceneManager.LoadScene("Prototype 1"); // Load Prototype 1 scene
    }

    private void StartChallenge3()
    {
        SceneManager.LoadScene("Challenge 3"); // Load Challenge 3 scene (note the space)
    }

    private void StartPrototype4()
    {
        SceneManager.LoadScene("Prototype 4"); // Load Prototype 4 scene
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Stop play mode in the editor
#else
        Application.Quit();
#endif
        Debug.Log("Game Exited"); // This will show in the console
    }
}
