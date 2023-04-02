using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _targeTransform;
    private float _lerpValue = 1;
    private Vector3 _offset;
    private Vector3 _startposition;
    [SerializeField] private Animation animation;

    private void Start()
    {
        _offset = transform.position - _targeTransform.position;
        _startposition = transform.position;
    }
    void LateUpdate()
    {
        Vector3 _newPosition = Vector3.Lerp(transform.position, new Vector3(_startposition.x, _startposition.y, _targeTransform.position.z + _offset.z) , _lerpValue * Time.deltaTime);
        transform.position = _newPosition;
    }
    public void RestartLvL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PlayAnimatiom() => animation.Play();
}
