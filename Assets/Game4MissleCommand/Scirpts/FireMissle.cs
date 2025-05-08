using UnityEngine;

public class FireMissle : MonoBehaviour
{

    [SerializeField] private GameObject[] launchers; // 3 roketatar
    [SerializeField] private GameObject missilePrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // en yakındaki roketin mause pozisyona doğru gitmesi
        {
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            GameObject closestLauncher = GetClosestLauncher(targetPos);
            if (closestLauncher != null)
            {
                Fire(closestLauncher.transform.position, targetPos);
            }
        }
        // en uzaktaki roketin mause pozisyonuna gitimesi
         if (Input.GetMouseButtonDown(1)) // Sağ tık
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            GameObject farthestLauncher = GetFarthestLauncher(mousePos);

            if (farthestLauncher != null)
            {
                Fire(farthestLauncher.transform.position, mousePos);
            }
        }
    }

    private GameObject GetClosestLauncher(Vector3 targetPos)
    {
        float closestDistance = Mathf.Infinity;
        GameObject closest = null;

        foreach (GameObject launcher in launchers)
        {
            float dist = Vector3.Distance(launcher.transform.position, targetPos);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closest = launcher;
            }
        }

        return closest;
    }

        GameObject GetFarthestLauncher(Vector3 targetPos)
    {
        GameObject farthest = null;
        float maxDistance = float.MinValue;

        foreach (GameObject launcher in launchers)
        {
            float distance = Vector3.Distance(launcher.transform.position, targetPos);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthest = launcher;
            }
        }

        return farthest;
    }

    private void Fire(Vector3 from, Vector3 to)
    {
    GameObject missile = Instantiate(missilePrefab, from, Quaternion.identity);

    // Rotasyon hesabı
    Vector3 direction = to - from;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    missile.transform.rotation = Quaternion.Euler(0, 0, angle);

    missile.GetComponent<Missile>().SetTarget(to);
    }
    //Math fonksiyonlarına bak ananın amı ya. 



    // [SerializeField] private GameObject[] targetObjects;
    // [SerializeField] private Vector3[] objectPositions;

    // private void Start()
    // {
    //     objectPositions = new Vector3[targetObjects.Length];
    //     GetObjectPos();
    // }
    // private void Update()
    // {
        
    //     GetMausePos();
    // }
    // private void GetMausePos()
    // {
    //     Vector3 mausePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     //Debug.Log("Güncel Mause Posizyonu:  "+mausePos);
    // }

    // private void GetObjectPos()
    // {
    //     for (int i = 0; i < targetObjects.Length; i++)
    //     {
    //         objectPositions[i]=targetObjects[i].transform.position;
    //         Debug.Log(targetObjects[i].name+"pozisyonu:"+objectPositions[i]);
    //     }
    // }
}
