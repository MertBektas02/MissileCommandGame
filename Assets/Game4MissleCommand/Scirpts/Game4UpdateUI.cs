using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Game4UpdateUI : MonoBehaviour
{

    [SerializeField] private GameObject upgradePanel;

    [SerializeField] private TextMeshProUGUI pointText;
    private int point;

    // Bu sınıfın tek örneğini tutacak private static değişken
    private static Game4UpdateUI _instance;

    // Dışarıdan erişilebilen, Singleton Instance property'si
    public static Game4UpdateUI Instance
    {
        get
        {
            // Eğer instance henüz atanmadıysa:
            if (_instance == null)
            {
                // Sahnedeki bir Game4UpdateUI objesini arıyoruz
                _instance = FindAnyObjectByType<Game4UpdateUI>();
                
                // Eğer sahnede yoksa, yeni bir GameObject oluşturup ona bu scripti ekliyoruz
                if (_instance == null)
                {
                    GameObject obj = new GameObject("Game4UpdateUI");
                    _instance = obj.AddComponent<Game4UpdateUI>();

                    // Oluşturulan objeyi sahne değişiminde yok olmaması için işaretliyoruz
                    DontDestroyOnLoad(obj);
                }
            }
            // Mevcut instance'ı geri döndürüyoruz
            return _instance;
        }
    }

    private void Awake()
    {
        // Eğer zaten bir instance varsa ve bu obje o değilse:
        if (_instance != null && _instance != this)
        {
            // Fazla olan objeyi yok ediyoruz
            Destroy(gameObject);
            return;
        }

        // Bu obje tek instance olacaksa, kendisini atıyoruz
        _instance = this;

        // Ve sahne değişiminde yok olmaması için ayarlıyoruz
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleUpgradePanel();
        }
    }


    public void G4UpdateUI()
    {
        point++;
        pointText.text=point.ToString();
        
    }

    private void ToggleUpgradePanel()
    {
        upgradePanel.SetActive(!upgradePanel.activeSelf);
    }
}
