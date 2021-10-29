using UnityEngine;

public class breakingPlateformes : MonoBehaviour
{
    public Animator animator;
    public AudioSource crackingSound;
    public float clearRadius = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 direction = transform.position - other.gameObject.transform.position;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();

            if (rb.velocity.y < 0)
            {
                crackingSound.Play();
                animator.SetTrigger("breakingDownTrigger");
            }
        }
    }

    private void Start()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, clearRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Plateformes")
            {
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
    }

    private void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}