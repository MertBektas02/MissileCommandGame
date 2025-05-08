using UnityEngine;
using UnityEngine.UI;

public class testFood : MonoBehaviour
{
    [SerializeField] private HungryBar hungryBar;
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hungryBar.FeedMonster(20);
            Destroy(gameObject);
        }
    }
}
