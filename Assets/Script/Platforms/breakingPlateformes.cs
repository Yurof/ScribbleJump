using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakingPlateformes : MonoBehaviour
{
    public Animator animator;
    public AudioSource crackingsound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 direction = transform.position - other.gameObject.transform.position;

            if (direction.y < 0)
            {
                crackingsound.Play();
                animator.SetTrigger("triggered");
            }
        } 
    }
    void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}
