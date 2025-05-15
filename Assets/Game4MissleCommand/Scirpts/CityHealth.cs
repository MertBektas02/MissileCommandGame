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


/* RemoveTargetFromList() metodunun çalışmasına ihtiyaç yok. Haliyle inspector'dan atama yapmaya da gerek yok. 
Onun işini MissileManager, SetROndomlyAndFİre() metodu hallediyor. */


/* !!ÖNEMLİ: EnemyMissile prefab'ine MissileManager Scriptine ulaşmak için atama yapmalıyım ama 
    herhangi bir atama yapmadan da script'e erişebiliyor ve removeTarget metodunu çalıştırabiliyorum.
    Bunun nasıl mümkün olduğunu bilmiyorum. GPT gizli bağlantılar olabilir diyor. Ne gizli bağlantısı abicim?
    
    "Unity'de scene object’leri prefab’ın içine Inspector’dan atamak mümkün değildir, çünkü sahne referansları prefab verisine kaydedilmez."
    
    
    problemi çözdüm. MissileManager'deki SetRondomlyAndFire metodunda bulunan enemyTargetPositions.RemoveAll(t=> t==null);
    kodu city destroy edilir edilmez null olan objeyi temizliyor. RemoveTargetFromList metodunun çalışmasına gerek kalmıyor.
    Ben de sanıyordum ki inspectordan atama yapılmadı. Yİne de reomve metdou çalışıyor.*/
