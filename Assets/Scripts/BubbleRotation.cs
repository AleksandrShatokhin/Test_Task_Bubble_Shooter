using UnityEngine;

public class BubbleRotation : BubbleController
{
    private GameObject aim;
    private float deviationCursor = 1.0f;
    private Vector3 pointA, pointB;
    private Vector3 direction;
    private float maxLeftAngle = 75.0f, maxRightAngle = 285.0f;

    private void Awake()
    {
        aim = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (isUsed && GameController.GetInstance().IsMousePositionAcceptableForClick())
        {
            CheckAngleRotation();
            RotateBubble();
        }
        
    }

    private void CheckAngleRotation()
    {
        // Left Angle
        if (transform.eulerAngles.z > maxLeftAngle && transform.eulerAngles.z < 180.0f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 75.0f);
        }

        // Right Angle
        if (transform.eulerAngles.z < maxRightAngle && transform.eulerAngles.z > 180.0f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 285.0f);
        }
    }

    private void RotateBubble()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionOnGameScreen = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));
        Vector3 offset = pointB - pointA;

        direction = Vector3.ClampMagnitude(offset, deviationCursor);

        if (MouseClick)
        {
            aim.SetActive(true);
            pointA = mousePositionOnGameScreen;
        }

        if (MousePressed)
        {
            pointB = mousePositionOnGameScreen;

            if (direction.x < 0)
            {
                transform.Rotate(0, 0, -direction.x);
            }

            if (direction.x > 0)
            {
                transform.Rotate(0, 0, -direction.x);
            }
        }

        if (MouseReleased)
        {
            aim.SetActive(false);
            IsUsed_Off();
        }
    }
}
