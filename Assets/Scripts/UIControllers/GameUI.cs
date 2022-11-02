using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    private const string textMessage = "Bubbles on Stage: ";
    private float pauseFlowTime = 0.0f;

    [SerializeField] private Button buttonPause;
    [SerializeField] private TextMeshProUGUI messageAboutBubblesOnStage;
    [SerializeField] private GameObject pauseUIPrefab;

    private void Start()
    {
        buttonPause.onClick.AddListener(CallPauseMenu);
    }

    private void CallPauseMenu()
    {
        Instantiate(pauseUIPrefab, pauseUIPrefab.transform.position, pauseUIPrefab.transform.rotation);
        Time.timeScale = pauseFlowTime;
    }

    public void OutputMessageOnScreen(int countBubbles)
    {
        messageAboutBubblesOnStage.text = textMessage + countBubbles.ToString();
    }
}
