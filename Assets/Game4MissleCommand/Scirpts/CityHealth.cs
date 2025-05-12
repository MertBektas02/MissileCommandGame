using UnityEngine;

public class CityHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private EnemyMissile  enemyMissileManager;

    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (enemyMissileManager!=null)
        {
            enemyMissileManager.RemoveTargetFromList(this.gameObject);
        }
        Destroy(this.gameObject);
    }
}
