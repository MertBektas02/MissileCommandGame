using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float speed=0.65f;
    

    // Update is called once per frame
    void Update()
    {
        transform.position+=Vector3.left*speed*Time.deltaTime;
    }
}
