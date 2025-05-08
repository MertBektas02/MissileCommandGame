using UnityEngine;

public class MovePong : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; // Hızı artırdım çünkü genelde mouse hızlı hareket eder.
    private Rigidbody2D rb;
    private Vector2 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mouse pozisyonunu dünya koordinatına çeviriyoruz.
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition = new Vector2(mouseWorldPos.x, rb.position.y); // Y ekseni sabit!
    }

    void FixedUpdate()
    {
        // Pozisyona doğru hareket ediyoruz
        Vector2 newPosition = Vector2.Lerp(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }
}