using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovingPLayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public int jumpforce = 5;
    public float horizontalforce = 3;
    public Camera mainCamera;

    private bool lookingright = true;
    public Animator animator;
    public float springmultiplicator = 2;

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
                animator.SetTrigger("jumpingt");
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                //animator.SetBool("jumping", false);
            }
        }

        if (other.gameObject.CompareTag("spring"))
        {
            animator.SetTrigger("jumpingt");
            rb.AddForce(Vector2.up * jumpforce* springmultiplicator, ForceMode2D.Impulse);
        }

        if (other.gameObject.CompareTag("Monsters"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (other.gameObject.CompareTag("brokenPlateformes"))
        {
            if (other.relativeVelocity.y > 0)
            {
                animator.SetTrigger("jumpingt");
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                //Destroy(other.collider.gameObject);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 theScale = transform.localScale;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jumpingt");
            rb.AddForce(Vector2.up*jumpforce, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow) )
        {
            if (lookingright)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
                lookingright = false;
            }
            rb.velocity = new Vector2(-horizontalforce, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!lookingright)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
                lookingright = true;
            }
            rb.velocity = new Vector2(horizontalforce, rb.velocity.y);
        }
    }
}
