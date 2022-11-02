using UnityEngine;

public class EndGameScene : MonoBehaviour
{
    private const string mainMenu = "MainMenu";

    public void ExitToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
        SelectedStateLevel.ClearStateLevel();
    }
}
