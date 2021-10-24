using UnityEngine;

public class Wrapping : MonoBehaviour
{
    public float xCoordinate = 2.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = new Vector2(xCoordinate, other.gameObject.transform.position.y);
        }
    }
}