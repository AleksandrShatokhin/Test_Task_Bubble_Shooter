using UnityEngine;

public class BubbleShot : BubbleController
{
    private Rigidbody2D rb_Bubble;

    private float forceRate = 10.0f;
    private Vector2 bubbleSpeed;

    private void Awake()
    {
        rb_Bubble = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bubbleSpeed = rb_Bubble.velocity;

        if (MouseReleased && isUsed && GameController.GetInstance().IsMousePositionAcceptableForClick())
        {
            Shot();
            IsUsed_Off();
        }
    }

    private void Shot()
    {
        rb_Bubble.AddForce(transform.up * forceRate, ForceMode2D.Impulse);
        GetComponent<CircleCollider2D>().enabled = true;
        StartCoroutine(GameController.GetInstance().CreateNewBubble());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)Layers.Bound)
        {
            var currentSpeed = bubbleSpeed.magnitude;
            Vector2 m_dir = Vector2.Reflect(bubbleSpeed.normalized, collision.contacts[0].normal);

            rb_Bubble.velocity = m_dir * currentSpeed;
        }
        else
        {
            rb_Bubble.velocity = BubbleStopped(this.rb_Bubble);
            this.gameObject.transform.SetParent(GameController.GetInstance().GetBubblesInScene().transform);
        }
    }
}