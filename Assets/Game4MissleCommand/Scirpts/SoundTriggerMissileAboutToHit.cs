using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class SoundTriggerMissileAboutToHit : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D enemyMissile)
    {
        if (enemyMissile.CompareTag("Game4EnemyMissile"))
        {
            Game4MissileAbtToHit();
        }
    }
    public void Game4MissileAbtToHit()
    {
        Game4SaundManager.Game4PlaySAund(SoundType.MISSILEABOUTTOHIT);
        Debug.Log("çalışıyor.");
    }
}
