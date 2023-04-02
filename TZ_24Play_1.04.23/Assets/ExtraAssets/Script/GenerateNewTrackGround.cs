using System.Collections.Generic;
using UnityEngine;

public class GenerateNewTrackGround : MonoBehaviour
{
    public GameObject[] TrackGround;
    [SerializeField] private GameObject[] _startTrackGround; 
    private Queue<GameObject> myQueue = new Queue<GameObject>();
    private Vector3 _LastTrackGrount;
    [SerializeField] HeroStackController HeroStackController;
    private void OnEnable()
    {
        EventManager.NewTrackGround += SetTrackGround;
    }
    private void OnDisable()
    {
        EventManager.NewTrackGround -= SetTrackGround;
    }
    private void Start()
    {
        foreach(GameObject startTrackGround in _startTrackGround)
        {
            myQueue.Enqueue(startTrackGround);
        }
        _LastTrackGrount = _startTrackGround[_startTrackGround.Length - 1].transform.position;
    }
    private void SetTrackGround()
    {
        GameObject newTrackGround = Instantiate(TrackGround[Random.Range(0, TrackGround.Length)], new Vector3(_LastTrackGrount.x, - 80, _LastTrackGrount.z + 30), Quaternion.identity, transform);
        newTrackGround.GetComponent<MoveUpTrackGround>().endY = _LastTrackGrount.y;
        myQueue.Enqueue(newTrackGround);
        _LastTrackGrount.z = newTrackGround.transform.position.z;
        DeleteTrackGround();

        HeroStackController.InitializedStackControllerByCube();
    }
    private void DeleteTrackGround()
    {
        Destroy(myQueue.Peek()); 
        myQueue.Dequeue();
    }
}
