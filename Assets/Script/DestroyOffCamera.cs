using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffCamera : MonoBehaviour
{


    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
