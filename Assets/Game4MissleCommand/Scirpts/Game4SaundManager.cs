using System.Runtime.InteropServices;
using UnityEngine;
public enum SoundType
{
    ESPLOSION,
    MISSILEABOUTTOHIT,
    THIRDEXPLOSION
}
[RequireComponent(typeof(AudioSource))]
public class Game4SaundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] SoundList;
   private static Game4SaundManager instance;
   private AudioSource audioSource;

    private void Awake()
    {
        instance=this;
    }
    private void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    public static void Game4PlaySAund(SoundType sound, float volume=1f)
   {
        instance.audioSource.PlayOneShot(instance.SoundList[(int)sound]);
   }
}
