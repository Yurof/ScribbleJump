using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlay : MonoBehaviour
{
    public AudioSource audiosource;

    private void OnEnable()
    {
        audiosource.Play();
    }
}
