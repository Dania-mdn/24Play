using UnityEngine;

public class MoveUpTrackGround : MonoBehaviour
{
    [HideInInspector] public float EndPositionY = 0;

    [Range(2, 6)]
    private int _speedMovengUp = 120;

    private void Update()
    {
        float newY = Mathf.MoveTowards(transform.position.y, EndPositionY, Time.deltaTime * _speedMovengUp);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z); 
    }
}
