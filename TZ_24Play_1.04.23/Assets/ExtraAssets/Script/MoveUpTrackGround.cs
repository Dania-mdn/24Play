using UnityEngine;

public class MoveUpTrackGround : MonoBehaviour
{
    public float endY = 0;
    [Range(2, 6)]
    private int speed = 120;

    private void Update()
    {
        float newY = Mathf.MoveTowards(transform.position.y, endY, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z); 
    }
}
