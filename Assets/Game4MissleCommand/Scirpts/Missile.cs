using UnityEngine;

public class Missile : MonoBehaviour
{
    private Vector3 target;
    public float speed = 5f;
    [SerializeField] private GameObject explosionPrefab;

    public void SetTarget(Vector3 t)
    {
        target = t;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 3f);
        
    }
}
