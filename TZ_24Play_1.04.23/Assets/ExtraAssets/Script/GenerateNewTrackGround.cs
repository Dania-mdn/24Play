using System.Collections.Generic;
using UnityEngine;

public class GenerateNewTrackGround : MonoBehaviour
{
    [SerializeField] private HeroStackController _heroStackController;
    [SerializeField] private GameObject[] _startTrackGround;

    public GameObject[] TrackGround;
    private Queue<GameObject> QueueTrackGround = new Queue<GameObject>();
    private Vector3 _LastTrackGrount;

    private void OnEnable()
    {
        GameManager.NewTrackGround += SetTrackGround;
    }
    private void OnDisable()
    {
        GameManager.NewTrackGround -= SetTrackGround;
    }
    private void Start()
    {
        foreach(GameObject startTrackGround in _startTrackGround)
        {
            QueueTrackGround.Enqueue(startTrackGround);
        }
        _LastTrackGrount = _startTrackGround[_startTrackGround.Length - 1].transform.position;
    }
    private void SetTrackGround()
    {
        GameObject newTrackGround = Instantiate(TrackGround[Random.Range(0, TrackGround.Length)], new Vector3(_LastTrackGrount.x, - 80, _LastTrackGrount.z + 30), Quaternion.identity, transform);
        newTrackGround.GetComponent<MoveUpTrackGround>().EndPositionY = _LastTrackGrount.y;
        QueueTrackGround.Enqueue(newTrackGround);
        _LastTrackGrount.z = newTrackGround.transform.position.z;
        DeleteTrackGround();

        _heroStackController.InitializedStackControllerByCube();
    }
    private void DeleteTrackGround()
    {
        Destroy(QueueTrackGround.Peek()); 
        QueueTrackGround.Dequeue();
    }
}
