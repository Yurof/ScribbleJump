using UnityEngine;

public class BluePlateformScript : MonoBehaviour
{
    public float blueSpeed = 2f;
    public float wallLimit = 2.2f;
    private bool direction = true;
    
    private void Update()
    {
        if (transform.position.x >= wallLimit)
        {
            direction = false;
        }
        if (transform.position.x <= -wallLimit)
        {
            direction = true;
        }

        if (direction)
        {
            transform.Translate((Vector2.right) * Time.deltaTime * blueSpeed);
        }
        else
        {
            transform.Translate((Vector2.left) * Time.deltaTime * blueSpeed);
        }
    }
}