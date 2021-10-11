using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappingRight : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(-2.5f, other.gameObject.transform.position.y, 10);
        }
    }
}
