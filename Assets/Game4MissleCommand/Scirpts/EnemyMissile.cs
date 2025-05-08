using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;


public class EnemyMissile : MonoBehaviour //Bu script bir MANAGER'dir.
{
    [Header("Missile spawn pos ve hedef pos")]
    [SerializeField] private GameObject[] enemyFirePositions;
    [SerializeField] private GameObject[] enemyTargetPositions;
    [Header("instantiate prefab")]
    [SerializeField] private GameObject enemyMisslePrefab;
    [Header("kaç saniyede bir spawn olacak?")]
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
        Transform launchPos=enemyFirePositions[UnityEngine.Random.Range(0,enemyFirePositions.Length)].transform; //missile'ın atış pos
        Transform targetPos=enemyTargetPositions[UnityEngine.Random.Range(0,enemyTargetPositions.Length)].transform; //missile'ın hedef pos
        GameObject missile=Instantiate(enemyMisslePrefab,launchPos.position,Quaternion.identity);
        missile.GetComponent<EnemyMissile1>().SetTarget(targetPos.position);

    }

    

}
