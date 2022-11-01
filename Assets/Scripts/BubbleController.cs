using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private enum MouseButton { Left = 0, Right = 1}
    protected enum BubbleCollor { white, red, black, blue, green, yellow}

    protected bool MouseClick { get { return Input.GetMouseButtonDown((int)MouseButton.Left); } }
    protected bool MousePressed { get { return Input.GetMouseButton((int)MouseButton.Left); } }
    protected bool MouseReleased { get { return Input.GetMouseButtonUp((int)MouseButton.Left); } }

    protected Vector2 BubbleStopped(Rigidbody2D rb_bubble)
    {
        rb_bubble.constraints = RigidbodyConstraints2D.FreezeAll;
        return new Vector2(0.0f, 0.0f);
    }

    [SerializeField] protected bool isUsed;
    protected void IsUsed_On() => isUsed = true;
    protected void IsUsed_Off() => isUsed = false;
}