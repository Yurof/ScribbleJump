using UnityEngine;

public class breakingPlateformes : MonoBehaviour
{
    public Animator animator;
    public AudioSource crackingSound;

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

    private void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}