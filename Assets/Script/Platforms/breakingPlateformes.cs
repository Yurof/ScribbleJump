using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakingPlateformes : MonoBehaviour
{
    public Animator animator;
    public AudioSource crackingsound;
    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 direction = other.GetContact(0).normal;
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.relativeVelocity.y < 0)
            {
                crackingsound.Play();
                animator.SetTrigger("triggered");
            }
        }

    }

}
