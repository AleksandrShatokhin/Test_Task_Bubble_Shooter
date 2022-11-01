using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private const string gameLevel = "GameLevel";

    [SerializeField] private Button buttonStartGame, buttonExit;

    private void Start()
    {
        buttonStartGame.onClick.AddListener(ClickButtonStartGame);
        buttonExit.onClick.AddListener(ClickButtonExit);
    }

    private void ClickButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameLevel);
    }

    private void ClickButtonExit()
    {
        Application.Quit();
    }
}
