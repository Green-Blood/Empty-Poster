using UnityEngine;
using Character;

public class EnemyAI : MonoBehaviour
{

    [Header("Physics")]
    public float speed = 300f;
    public bool allowRunning = false;
    public float gameoverDistance = 1f;
    public float jumpForce = 10f;
    public Transform target;

    Rigidbody2D rb;

    Animator animator;

    public CharacterAnimator characterAnimator;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (allowRunning)
        {
            // Movement
            Vector2 force = new Vector2(-1f * speed * Time.deltaTime, rb.velocity.y);
            float velocityX = Mathf.Abs(rb.velocity.x);
            animator.SetFloat("running", velocityX);
            rb.velocity = force;
            if (Vector2.Distance(transform.position, target.transform.position) < gameoverDistance)
            {
                // trigger game over (animation)
                allowRunning = false;
                animator.SetTrigger("hit");
                characterAnimator.SetIsFall();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out ObstacleJump enemy)) return;
        rb.AddForce(new Vector2(rb.velocity.y, jumpForce), ForceMode2D.Impulse);
    }
}