using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Destroyer : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject TheDestroyer;
    private bool fallingDownBool=false;
    private int stopmov=0;
    public AudioSource fallingsound;
    private BoxCollider2D bc;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (stopmov > 650)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (stopmov < 150+(transform.position.y-mainCamera.transform.position.y) && fallingDownBool)
        {
            mainCamera.transform.Translate(Vector3.down * Time.deltaTime * 20f);

        }

        if (fallingDownBool)
        {

            stopmov += 1;
            //bc.enabled = false;
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            transform.Translate(Vector2.down * Time.deltaTime);

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            fallingsound.Play();
            bc.enabled=false;
            fallingDownBool = true;
        }
/*        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(other.collider.gameObject);
        }*/
    }
/*    void OnCollisionExit2D(Collision2D other)
    {

        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(other.collider.gameObject);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent != null)
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}