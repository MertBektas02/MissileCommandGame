using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;


public class EnemyMissile : MonoBehaviour //Bu script bir MANAGER'dir.
{
    [Header("Missile spawn pos ve hedef pos")] //(hedef pos'lar array idi. list'e çevrildi çünkü runtime'da ekleme ve çıkarma yapılması gerek. array'de bu mümkün değilmiş.)
    [SerializeField] private GameObject[] enemyFirePositions;
    [SerializeField] private List<GameObject> enemyTargetPositions;
    [Header("instantiate prefab")]
    [SerializeField] private GameObject enemyMisslePrefab;
    [Header("Missile kaç saniyede bir spawn olacak?")]
    [SerializeField] private float spawnInterval = 5f;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>spawnInterval)
        {
            SelectTargetRondomlyAndFire();
            timer=0f;
        }
    }

    private void SelectTargetRondomlyAndFire()
    {


        if(enemyTargetPositions.Count==0) return;
        enemyTargetPositions.RemoveAll(t=> t==null); // ilk return liste boşsa scriptten çıkması için, ikinci return null hedefleri temizlemesi için.
        if(enemyTargetPositions.Count==0) return;

        Transform launchPos=enemyFirePositions[UnityEngine.Random.Range(0,enemyFirePositions.Length)].transform; //missile'ın atış pos // hedef ve atışlardan rastgele pos al.
        Transform targetPos=enemyTargetPositions[UnityEngine.Random.Range(0,enemyTargetPositions.Count)].transform; //missile'ın hedef pos. Length'i array'de count'u list'te kullan
        GameObject missile=Instantiate(enemyMisslePrefab,launchPos.position,Quaternion.identity);
        missile.GetComponent<EnemyMissile1>().SetTarget(targetPos.position);

    }

    public void AddTargetToList(GameObject target)
    {
        if(!enemyTargetPositions.Contains(target)){enemyTargetPositions.Add(target);} //ileride upgrade sistemini getirince add target yapmak gerekebilir.
    }
    public void RemoveTargetFromList(GameObject target)
    {
        if(enemyTargetPositions.Contains(target)){enemyTargetPositions.Remove(target);}
    }
}

/* !!ÖNEMLİ: EnemyMissile prefab'ine MissileManager Scriptine ulaşmak için atama yapmalıyım ama 
    herhangi bir atama yapmadan da script'e erişebiliyor ve removeTarget metodunu çalıştırabiliyorum.
    Bunun nasıl mümkün olduğunu bilmiyorum. GPT gizli bağlantılar olabilir diyor. Ne gizli bağlantısı abicim?
    
    "Unity'de scene object’leri prefab’ın içine Inspector’dan atamak mümkün değildir, çünkü sahne referansları prefab verisine kaydedilmez.
    aksi halde "Type Mismatch" hatası almalıyım."*/
