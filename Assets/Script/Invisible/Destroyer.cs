using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public CameraMoving cameraMoving;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            transform.parent = null;
            cameraMoving.FallingDown();
        }
    }
}