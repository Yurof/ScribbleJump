using System;
using System.Collections;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public float ecart = 0.1f;
    public GameObject player;
    public float fallingTime = 2f;
    public float cameraTranslationLimit = 20f;
    public float cameraTranslationSpeed = 20f;
    public float fallingGap = 3f;
    public AudioSource fallingsound;
    public Transform Background;

    private float posstart;
    private float delta;
    private bool fallingDownBool = false;
    private float cameraCurrentPosition;
    private IEnumerator coroutine;

    private void Start()
    {
        posstart = player.transform.position.y;
        coroutine = FallingDownCoroutine(fallingTime);
    }

    private void Update()
    {
        if (player.transform.position.y > ecart + posstart)
        {
            transform.Translate(Vector2.up * (player.transform.position.y - (ecart + posstart)));
            posstart = player.transform.position.y;
        }

        if ((cameraTranslationLimit + delta > cameraCurrentPosition - transform.position.y) && fallingDownBool)
        {
            transform.Translate(Vector2.down * Time.deltaTime * cameraTranslationSpeed);
        }
    }

    public void FallingDown()
    {
        fallingDownBool = true;
        fallingsound.Play();
        Background.parent = null;
        delta = (float)Math.Max(player.transform.position.y - transform.position.y + fallingGap, 0);
        cameraCurrentPosition = transform.position.y;
        StartCoroutine(coroutine);
    }

    private IEnumerator FallingDownCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
}