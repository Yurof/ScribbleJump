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
    public AudioSource fallingsound;
    public AudioSource blackholesound;
    private bool fallingDownBool = false;
    private bool fallingBlackHole = false;
    private GameObject BlackHole;
    private BoxCollider2D bc;
    private int i=0;
    public Camera maincamera;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
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

        if (other.gameObject.CompareTag("Monsters")  )
        {
            fallingDownBool = true;
            animator.SetTrigger("stars_t");
            fallingsound.Play();

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (other.gameObject.CompareTag("BlackHoles"))
        {
            BlackHole = other.transform.gameObject;
            fallingBlackHole = true;
            blackholesound.Play();
            animator.SetTrigger("blackhole_t");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //transform.position = other.transform.position;


            coroutine = BLackHoleDeath(1.5f);
            StartCoroutine(coroutine);
            
            //yield return new WaitForSeconds(5);
           // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        }



    }
    private void Update()
    {

        if (i>720)
        {
          SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (i< 160 && fallingDownBool)
        {
            maincamera.transform.Translate(Vector3.down * Time.deltaTime * 20f);

        }

        if (fallingDownBool)
        {

            i += 1;
            bc.enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            transform.Translate(Vector2.down * Time.deltaTime);

        }

        if (fallingBlackHole)
        {
            //transform.RotateAround(BlackHole.transform.position, new Vector3(0, 0, 20), Time.deltaTime * 10);
            transform.position = Vector3.MoveTowards(transform.position, BlackHole.transform.position, Time.deltaTime*20);
        }
    }

    IEnumerator BLackHoleDeath(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
