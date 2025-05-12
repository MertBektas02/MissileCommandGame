using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyMissile1 : MonoBehaviour
{
    [Header("Missile speed")]
    [SerializeField] private float speed = 2f;
    [Header("Prefabs")]
    [SerializeField] private GameObject enemyExplotionPrefab;

    [SerializeField] private GameObject friendlyExplotionPrefab;
    [SerializeField] private GameObject popUpText;
    private Vector3 target;//missile'ın burnunu hedefe doğru çevirmesi için pos.
    private string missilePoint="+1";
    [Header("bağımlılıklar")]
    // [SerializeField] private EnemyMissile  enemyMissileManager;

     [Header("missile damage")]
     [SerializeField] private int missileDamageAmount=100;



    



    public void SetTarget(Vector3 targetPosition)
    {
        target = targetPosition;
        // Ucu hedefe baksın
        Vector3 dir = (target - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90); 
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {

           
            GameObject explosion=Instantiate(enemyExplotionPrefab,transform.position,Quaternion.identity);
            Destroy(gameObject); 
            Destroy(explosion,3f);
        }

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Game4FriendlyMissile"))
        {
            //Debug.Log("is trigger gerçekleşti");
            GameObject explosion= Instantiate(friendlyExplotionPrefab,transform.position,Quaternion.identity);
            Game4UpdateUI.Instance.G4UpdateUI();
            ShowPopUpText();
            Destroy(this.gameObject);
            Destroy(explosion,3f);
          
        }
        if (other.CompareTag("Game4Building"))
        {
            CityHealth health=other.GetComponent<CityHealth>();
            if (health!=null)
            {
                health.TakeDamage(missileDamageAmount);
            }
        }
    }
    void ShowPopUpText()
    {
        //GameObject textPopUp = Instantiate(popUpText, transform.position, Quaternion.identity, transform);
        //üstteki kodda en sondaki transform, içinde bulunduğu objeyi parent olarak alıyor. Parent anında destroy edildiği için text yaratılıp hemen siliniyor.
        Vector3 randomOffset=new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f),0.5f,0f);
        GameObject floatingText=Instantiate(popUpText,transform.position+randomOffset,Quaternion.identity);
        //floatingText.GetComponent<TextMesh>().text=missilePoint.ToString(); //Animasyon kaydettiğimde text 0 0 0 pozisyonlarında instantiate ediliyordu. Sebebi bu kod parçasıymış.
        //Ayrıca number animasyonunun position problemini child ekleyerek çözdüm. child halen fare pozisyonunda spawn oluyor. parent'in pozisyonu baz alınmıyor.
        TextMesh textComponent = floatingText.GetComponentInChildren<TextMesh>();
        if (textComponent != null)
        {
            textComponent.text = missilePoint;
            
        }
        Destroy(floatingText,1.25f);
        
    }
}


/* !!ÖNEMLİ: EnemyMissile prefab'ine MissileManager Scriptine ulaşmak için atama yapmalıyım ama 
    herhangi bir atama yapmadan da script'e erişebiliyor ve removeTarget metodunu çalıştırabiliyorum.
    Bunun nasıl mümkün olduğunu bilmiyorum. GPT gizli bağlantılar olabilir diyor. Ne gizli bağlantısı abicim?
    
    "Unity'de scene object’leri prefab’ın içine Inspector’dan atamak mümkün değildir, çünkü sahne referansları prefab verisine kaydedilmez."*/
