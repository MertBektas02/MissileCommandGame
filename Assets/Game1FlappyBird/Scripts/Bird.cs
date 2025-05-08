using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float jumpForce=1f;
    private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed=1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity=Vector2.up*jumpForce;
            // float angle = Mathf.Clamp(rb.linearVelocity.y * 5f, -90f, 45f);
            // transform.rotation = Quaternion.Euler(0, 0, angle);
            
        }
        // float angle = Mathf.Clamp(rb.linearVelocity.y * 5f, -90f, 45f);
        // Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        // transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void FixedUpdate()
    {
        transform.rotation=Quaternion.Euler(0,0,rb.linearVelocity.y*rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
