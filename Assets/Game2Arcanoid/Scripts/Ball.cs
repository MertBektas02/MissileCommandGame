using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
        }
    }
}
