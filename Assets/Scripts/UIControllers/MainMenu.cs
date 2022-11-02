using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private const string gameLevel = "GameLevel";

    [SerializeField] private Button buttonStartReadyLevel, buttonStartGeneratedLevel, buttonExit;

    private void Start()
    {
        buttonStartReadyLevel.onClick.AddListener(ClickButtonStartReadyLevel);
        buttonStartGeneratedLevel.onClick.AddListener(ClickButtonStartGeneratedLevel);
        buttonExit.onClick.AddListener(ClickButtonExit);
    }

    private void ClickButtonStartReadyLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameLevel);
        SelectedStateLevel.SetStateReadyLevel();
    }

    private void ClickButtonStartGeneratedLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameLevel);
        SelectedStateLevel.SetStateGeneratedLevel();
    }

    private void ClickButtonExit()
    {
        Application.Quit();
    }
}
