using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    [SerializeField] private string bubbleColor;
    public string GetBubbleColor() => bubbleColor;

    private float radius = 0.3f;
    [SerializeField] private LayerMask bubbleMask;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (collision.gameObject.GetComponent<BubbleCollision>().GetBubbleColor() == this.bubbleColor)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        Collider2D[] collid = Physics2D.OverlapCircleAll(this.transform.position, radius, bubbleMask);

        foreach (var id in collid)
        {
            if (id.GetComponent<BubbleCollision>().GetBubbleColor() == this.bubbleColor)
            {
                DestroyImmediate(id.gameObject);
            }
        }
    }
}