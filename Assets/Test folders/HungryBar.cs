using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HungryBar : MonoBehaviour
{
    private float totalHungry=100f;
    [SerializeField] private Image foodBar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            FeedMonster(20);
        }
    }

    public void FeedMonster(float giveFood)
    {
       totalHungry+=giveFood;
       totalHungry=Mathf.Clamp(totalHungry,0,100);
       foodBar.fillAmount=totalHungry/100f;
    }

    void TakeDamage(float damage)
    {
        totalHungry-=damage;
        foodBar.fillAmount=totalHungry/100f;
    }

    //feed the monster
     
    
}
