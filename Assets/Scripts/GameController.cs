using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    [SerializeField] private List<GameObject> bubbleList;

    private void Awake()
    {
        instance = this;
    }

    public void CreateNewBubble()
    {
        int numberBubble = Random.Range(0, bubbleList.Count - 1);

        Instantiate(bubbleList[numberBubble], new Vector3(0.0f, -4.5f, 0.0f), Quaternion.identity);
    }
}
