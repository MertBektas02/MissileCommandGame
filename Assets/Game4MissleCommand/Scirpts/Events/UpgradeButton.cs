using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private FloatEventSO missileSpeedEvent;
    [SerializeField] private float speedMultiplier = 1.2f;
    [SerializeField] private int maxClicks;

    private bool purchased = false;
    private int clickCount =0;

    public void OnCliclk()
    {
        if (purchased) return;
        clickCount++;

        
        missileSpeedEvent.Raise(speedMultiplier);

        if (clickCount >= maxClicks)
        {
            purchased = true;
            Debug.Log(clickCount);
        }
    }

   
}
