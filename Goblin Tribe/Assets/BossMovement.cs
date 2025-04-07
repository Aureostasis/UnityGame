using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform Player;
    public Transform spriteHolder;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Player == null) return;

        // Get direction to player
        Vector3 direction = Player.position - transform.position;
        direction.Normalize();
        movement = direction;

        // Flip sprite left/right depending on player's position
        if (Player.position.x < transform.position.x)
        {
            spriteHolder.localScale = new Vector3(-1, 1, 1); // Face left
        }
        else
        {
            spriteHolder.localScale = new Vector3(1, 1, 1); // Face right
        }
    }

    void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
