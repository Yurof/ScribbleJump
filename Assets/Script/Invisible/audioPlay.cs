using UnityEngine;

public class audioPlay : MonoBehaviour
{
    public AudioSource audiosource;

    private void OnEnable()
    {
        audiosource.Play();
    }
}