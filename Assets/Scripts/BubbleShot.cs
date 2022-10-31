using System.Collections;
using System.Collections.Generic;
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
    }

    private void FixedUpdate()
    {
        if (MouseReleased)
        {
            Shot();
        }
    }

    private void Shot() => rb_Bubble.AddForce(transform.up * forceRate, ForceMode2D.Impulse);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            var currentSpeed = bubbleSpeed.magnitude;
            Vector2 m_dir = Vector2.Reflect(bubbleSpeed.normalized, collision.contacts[0].normal);

            rb_Bubble.velocity = m_dir * currentSpeed;
        }
        else
        {
            rb_Bubble.velocity = bubbleStopped;
        }
    }
}