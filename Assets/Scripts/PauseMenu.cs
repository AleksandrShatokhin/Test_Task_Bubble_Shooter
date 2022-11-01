using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private const string mainMenu = "MainMenu";
    private float normalFlowTime = 1.0f;

    [SerializeField] private Button buttonContinue, buttonExit;

    private void Start()
    {
        buttonContinue.onClick.AddListener(ClickButtonContinue);
        buttonExit.onClick.AddListener(ClickButtonExit);
    }

    private void ClickButtonContinue()
    {
        Time.timeScale = normalFlowTime;
        Destroy(this.gameObject);
    }

    private void ClickButtonExit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
    }
}
