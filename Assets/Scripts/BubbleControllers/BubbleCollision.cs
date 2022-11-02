using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    [SerializeField] private string bubbleColor;
    public string GetBubbleColor() => bubbleColor;

    private float radius = 0.3f;
    [SerializeField] private LayerMask bubbleMask;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)Layers.Bubbles)
        {
            if (collision.gameObject.GetComponent<BubbleCollision>().GetBubbleColor() == this.bubbleColor)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        ChainReactionOfDestroyBubbles();
    }

    private void ChainReactionOfDestroyBubbles()
    {
        Collider2D[] collid = Physics2D.OverlapCircleAll(this.transform.position, radius, bubbleMask);

        foreach (var id in collid)
        {
            if (id.GetComponent<BubbleCollision>().GetBubbleColor() == this.bubbleColor)
            {
                Destroy(id.gameObject);
            }
        }
    }
}