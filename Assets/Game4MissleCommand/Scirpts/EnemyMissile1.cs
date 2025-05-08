using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyMissile1 : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject enemyExplotionPrefab;

    [SerializeField] private GameObject friendlyExplotionPrefab;
    private Vector3 target;
    [SerializeField] private GameObject popUpText;
    private string missilePoint="+1";



    



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
            Destroy(gameObject,0.1f); 
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
    }
    void ShowPopUpText()
    {
        //GameObject textPopUp = Instantiate(popUpText, transform.position, Quaternion.identity, transform);
        //üstteki kodda en sondaki transform, içinde bulunduğu objeyi parent olarak alıyor. Parent anında destroy edildiği için text yaratılıp hemen siliniyor.
        Vector3 randomOffset=new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f),0.5f,0f);
        GameObject floatingText=Instantiate(popUpText,transform.position+randomOffset,Quaternion.identity);
        //floatingText.GetComponent<TextMesh>().text=missilePoint.ToString(); //Animasyon kaydettiğimde text 0 0 0 pozisyonlarında instantiate ediliyordu. Sebebi bu kod parçasıymış.
        //Ayrıca number animasyonunun position problemini child ekleyerek çözdüm. Parent halen fare pozisyonunda spawn oluyor. Child'in pozisyonu baz alınmıyor.
        TextMesh textComponent = floatingText.GetComponentInChildren<TextMesh>();
        if (textComponent != null)
        {
            textComponent.text = missilePoint;
            
        }
        Destroy(floatingText,1.25f);

        
    }
}
