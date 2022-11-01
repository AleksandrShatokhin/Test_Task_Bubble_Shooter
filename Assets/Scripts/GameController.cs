using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    private const string EndGameScene = "EndGame";

    [SerializeField] private List<GameObject> bubbleList;
    [SerializeField] private GameObject bubblesInScene;
    [SerializeField] private GameUI gameUI;

    [SerializeField] private GameObject boundLeft, boundRight;

    private Vector3 startPositionBubbles = new Vector3(0.0f, -3.5f, 0.0f);

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(CheckCountBubblesInScene());

        ArrangeBounds();
    }

    private void ArrangeBounds()
    {
        Vector3 poinX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        boundLeft.transform.position = new Vector2(-poinX.x, 0);
        boundRight.transform.position = new Vector2(poinX.x, 0);
    }

    public IEnumerator CreateNewBubble(float delay = 0.3f)
    {
        int numberBubble = Random.Range(0, bubbleList.Count);
        
        yield return new WaitForSeconds(delay);
        Instantiate(bubbleList[numberBubble], startPositionBubbles, Quaternion.identity);
    }

    public IEnumerator CheckCountBubblesInScene(float delay = 0.2f)
    {
        while (true)
        {
            int countBubbles = bubblesInScene.transform.childCount;

            gameUI.OutputMessageOnScreen(countBubbles);

            if (countBubbles == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(EndGameScene);
            }

            yield return new WaitForSeconds(delay);
        }
    }

    public bool IsMousePositionAcceptableForClick()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionOnGameScreen = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));

        bool isCanPlay;

        if (mousePositionOnGameScreen.y <= -4 || mousePositionOnGameScreen.y >= 0)
        {
            isCanPlay = false;
        }
        else
        {
            isCanPlay = true;
        }

        return isCanPlay;
    }

    public GameObject GetBubblesInScene() => bubblesInScene;
}
