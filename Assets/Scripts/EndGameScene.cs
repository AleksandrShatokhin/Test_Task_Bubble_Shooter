using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScene : MonoBehaviour
{
    private const string mainMenu = "MainMenu";

    public void ExitToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
    }
}
