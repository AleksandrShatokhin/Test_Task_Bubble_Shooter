using UnityEngine;

public class BoundBottom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)Layers.Bubbles)
        {
            Destroy(collision.gameObject);
        }
    }
}
