using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject TheDestroyer;
    public GameObject Death;
    private bool cameramov;
    private int stopmov=0;
    private int i = 0;
    void Start()
    {
        cameramov = false;
    }

    void Update()
    {
        if (cameramov)
        {
            if (stopmov < 170) { 
                mainCamera.transform.Translate(Vector3.down * Time.deltaTime * 20f);
                stopmov += 1;
            } 
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {   
        i += 1;
        Debug.Log(i);
        if (other.gameObject.CompareTag("Player"))
        {
            cameramov = true;

            other.transform.position=new Vector2(other.transform.position.x, transform.position.y - 0.1f);
            TheDestroyer.transform.parent = null;
            TheDestroyer.transform.position = new Vector2(Death.transform.position.x, Death.transform.position.y - 13f);
            Death.transform.parent = null;
            Death.transform.position = new Vector2(Death.transform.position.x, Death.transform.position.y - 12f);
            //mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.x-7.5f, mainCamera.transform.position.z);
        }
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(other.collider.gameObject);
        }
    }


}