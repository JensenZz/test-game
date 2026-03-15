using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;

        if (animator != null)
        {
            animator.SetFloat("h", Mathf.Abs(moveX));
            animator.SetFloat("s", Mathf.Abs(moveY));
        }

        if (spriteRenderer != null)
        {
            if (moveX < 0f)
            {
                spriteRenderer.flipX = true;
            }
            else if (moveX > 0f)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    private void OnDisable()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
