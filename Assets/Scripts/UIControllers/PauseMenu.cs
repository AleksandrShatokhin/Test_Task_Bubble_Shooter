using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private const string mainMenu = "MainMenu";
    private const string gameLevel = "GameLevel";

    private float normalFlowTime = 1.0f;

    [SerializeField] private Button buttonContinue, buttonRestart, buttonExit;

    private void Start()
    {
        buttonContinue.onClick.AddListener(ClickButtonContinue);
        buttonRestart.onClick.AddListener(ClickButtonRestart);
        buttonExit.onClick.AddListener(ClickButtonExit);
    }

    private void ClickButtonContinue()
    {
        Time.timeScale = normalFlowTime;
        Destroy(this.gameObject);
    }

    private void ClickButtonRestart()
    {
        Time.timeScale = normalFlowTime;
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameLevel);
        Destroy(this.gameObject);
    }

    private void ClickButtonExit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
        SelectedStateLevel.ClearStateLevel();
    }
}
