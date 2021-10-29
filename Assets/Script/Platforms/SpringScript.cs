using UnityEngine;

public class SpringScript : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 direction = other.GetContact(0).normal;
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.relativeVelocity.y < 0)
            {
                animator.SetTrigger("trigger");
            }
        }
    }
}