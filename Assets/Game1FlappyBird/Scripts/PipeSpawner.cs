using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime=1.5f;
    [SerializeField] private float heightRange=0.45f;
    [SerializeField] private GameObject pipe;
    private float timer;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if (timer>maxTime)
        {
            SpawnPipe();
            timer=0;
        }
        timer+=Time.deltaTime;
    }
    void SpawnPipe()
    {
        Vector3 spawnPos=transform.position+ new Vector3(0,UnityEngine.Random.Range(-heightRange,heightRange));
        GameObject _pipe=Instantiate(pipe,spawnPos,quaternion.identity);
        Destroy(_pipe,10f);
    }
}
