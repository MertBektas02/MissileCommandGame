using UnityEngine;

public class Missile : MonoBehaviour
{
    private Vector3 target;
    public float baseSpeed = 1f;
    private float currentSpeed;
    [SerializeField] private GameObject explosionPrefab;

    public void SetTarget(Vector3 t)
    {
        target = t;
    }
    public void ApplySpeedMultiplier(float multiplier)
    {
        currentSpeed=baseSpeed*multiplier;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, currentSpeed * Time.deltaTime);
        Debug.Log(currentSpeed);
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
