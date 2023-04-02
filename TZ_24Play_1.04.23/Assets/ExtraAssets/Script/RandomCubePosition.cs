using UnityEngine;

public class RandomCubePosition : MonoBehaviour
{
    private int[] _positionX = new int[4] { -1, 0, 1, 2 };
    void Start()
    {
        transform.position = new Vector3(transform.parent.position.x + _positionX[Random.Range(0, _positionX.Length)], transform.position.y, transform.position.z);
    }
}
