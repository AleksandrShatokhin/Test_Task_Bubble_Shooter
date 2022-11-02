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

    [SerializeField] private GameObject boundLeft, boundRight, boundTop;

    private Vector3 startPositionBubbles = new Vector3(0.0f, -3.5f, 0.0f);

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ArrangeBounds();

        if (SelectedStateLevel.GetStateLevel() == SelectedStateLevel.StateLevel.Generated.ToString())
        {
            ClearReadyLevel();
            GeneratedBubbleInLevel();
        }

        CreateFirstPlayerBubble();

        StartCoroutine(CheckCountBubblesInScene());
    }

    private void ClearReadyLevel()
    {
        for (int i = 0; i < bubblesInScene.transform.childCount; i++)
        {
            Destroy(bubblesInScene.transform.GetChild(i).gameObject);
        }
    }

    private void ArrangeBounds()
    {
        Vector3 boundsScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        boundLeft.transform.position = new Vector2(-boundsScreen.x, 0);
        boundRight.transform.position = new Vector2(boundsScreen.x, 0);
        boundTop.transform.position = new Vector2(0, boundsScreen.y);
    }

    private void GeneratedBubbleInLevel()
    {
        List<GameObject> bubbles = new List<GameObject>();

        for (int i = 0; i < bubblesInScene.transform.childCount; i++)
        {
            int numberBubble = Random.Range(0, bubbleList.Count);

            GameObject prefab = bubbleList[numberBubble];
            Vector3 positionPrefab = bubblesInScene.transform.GetChild(i).transform.position;

            GameObject bubble = Instantiate(prefab, positionPrefab, prefab.transform.rotation);
            bubbles.Add(bubble);

            Destroy(bubblesInScene.transform.GetChild(i).gameObject);

            bubble.GetComponent<CircleCollider2D>().enabled = true;
            bubble.GetComponent<BubbleRotation>().enabled = false;
            bubble.GetComponent<BubbleShot>().enabled = false;
            bubble.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            bubble.GetComponent<Rigidbody2D>().mass = 50;
        }

        foreach (GameObject bubble in bubbles)
        {
            bubble.transform.SetParent(bubblesInScene.transform);
        }
    }

    private void CreateFirstPlayerBubble()
    {
        StartCoroutine(CreateNewBubble());
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


public static class SelectedStateLevel
{
    public enum StateLevel { Ready, Generated}

    private static string stateLevel;
    public static string GetStateLevel() => stateLevel;


    public static void SetStateReadyLevel() => stateLevel = StateLevel.Ready.ToString();
    public static void SetStateGeneratedLevel() => stateLevel = StateLevel.Generated.ToString();
    public static void ClearStateLevel() => stateLevel = null;
}