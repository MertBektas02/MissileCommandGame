using Unity.Mathematics;
using UnityEngine;

public class Asteroid  : MonoBehaviour
{
    public int size = 3;
    public AsteroidGameManager gameManager; // Referansı da güncelledik

    private void Start()
    {
        transform.localEulerAngles = 0.5f * size * Vector3.one;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(UnityEngine.Random.value, UnityEngine.Random.value).normalized;
        float spawnSpeed = UnityEngine.Random.Range(4f - size, 5f - size);
        rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            gameManager.asteroidCount--;
            Destroy(collision.gameObject);

                if (size>1 )
            {
                for (int i = 0; i < 2; i++)
                {
                Asteroid newAsteroid=Instantiate(this,transform.position,quaternion.identity);
                newAsteroid.size=size-1;
                newAsteroid.gameManager=gameManager;
                }
            }
             Destroy(gameObject);
        }
    }
}
