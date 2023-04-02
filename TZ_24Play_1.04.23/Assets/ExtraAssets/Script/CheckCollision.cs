using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("TrackGround") || collision.transform.CompareTag("CubeWall"))
        {
            EventManager.DoEndGame();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Chek"))
        {
            EventManager.DoNewTrackGround();
        }
    }
}
