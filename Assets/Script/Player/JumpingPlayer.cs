using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpingPlayer : MonoBehaviour
{
    public Animator animator;
    public float springmultiplicator = 2;
    public int jumpforce = 6;
    private Rigidbody2D rb;
    public AudioSource springsound;
    public AudioSource jumpgsound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 direction = other.GetContact(0).normal;

        if (other.gameObject.CompareTag("Plateformes"))
        {
            if (other.relativeVelocity.y > 0)
            {
                jumpgsound.Play();
                animator.SetTrigger("jumpingt");
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                //animator.SetBool("jumping", false);
            }
        }
        if (other.gameObject.CompareTag("brokenPlateformes"))
        {
            if (other.relativeVelocity.y > 0)
            {
                animator.SetTrigger("jumpingt");
                //rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                //Destroy(other.collider.gameObject);
            }
        }



        if (other.gameObject.CompareTag("spring"))
        {
            if (other.relativeVelocity.y > 0)
            {
                springsound.Play();
                animator.SetTrigger("jumpingt");
                rb.AddForce(Vector2.up * jumpforce * springmultiplicator, ForceMode2D.Impulse);
            }
        }

        if (other.gameObject.CompareTag("Monsters") || other.gameObject.CompareTag("BlackHoles"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }



    }
}
