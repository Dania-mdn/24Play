using System.Collections;
using UnityEngine;

public class MoveUpCullectCube : MonoBehaviour
{
    [Range(2, 5)]
    [SerializeField] private float _duration = 3;

    [Range(2, 6)]
    [SerializeField] private float _height = 4;
    void Start()
    {
        StartCoroutine(MoveUp());
    }
    IEnumerator MoveUp()
    {
        float elapsedTime = 0.0f;

        Vector3 _starPosition = transform.position;
        Vector3 _endPosition = _starPosition + new Vector3(0, _height, -4);

        while (elapsedTime < _duration)
        {
            transform.position = Vector3.Lerp(_starPosition, _endPosition, (elapsedTime / _duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
