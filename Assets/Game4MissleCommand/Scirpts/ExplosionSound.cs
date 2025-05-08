using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    public void PlaySound()
    {
        Game4SaundManager.Game4PlaySAund(SoundType.ESPLOSION);
    }
}
