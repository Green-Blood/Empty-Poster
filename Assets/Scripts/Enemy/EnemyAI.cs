using UnityEngine;
using Character;

public class EnemyAI : MonoBehaviour
{

    [Header("Physics")]
    public float speed = 300f;
    public bool allowRunning = false;
    public float gameoverDistance = 1f;
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
            Vector2 force = Vector2.left * speed * Time.deltaTime;
            float velocityX = Mathf.Abs(rb.velocity.x);
            animator.SetFloat("running", velocityX);
            if (velocityX < Mathf.Abs(force.x))
            {
                rb.AddForce(force);
            }
            if (Vector2.Distance(transform.position, target.transform.position) < gameoverDistance)
            {
                // trigger game over (animation)
                allowRunning = false;
                animator.SetTrigger("hit");
                characterAnimator.SetIsFall();
            }
        }
    }
}