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
    public float horizontalforce = 2;
    public Camera mainCamera;
    public float jumpforce = 6;
    private SpriteRenderer mysprite;

    private bool lookingright = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mysprite = GetComponent<SpriteRenderer>();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*jumpforce, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKeyDown("left") )
        {
            lookingright = false;
            Flip();
            rb.velocity = new Vector2(-horizontalforce, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown("right"))
        {
            lookingright = true;
            Flip();
            rb.velocity = new Vector2(horizontalforce, rb.velocity.y);
        }
    }

    private void Flip()
    {
        Debug.Log("FLIP");
        if (!lookingright)
        {
            mysprite.flipX = true;
        }
        else
        {
            mysprite.flipX = false;
        }
        
        //transform.Rotate(0f, 180f, 0);

        /*Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        */
    }

}
