using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("TrackGround") || collision.transform.CompareTag("CubeWall"))
            _gameManager.EndGameMethod();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Chek"))
            GameManager.DoNewTrackGround();
    }
}
