using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroStackController : MonoBehaviour
{
    public List<GameObject> BlockList = new List<GameObject>();
    private GameObject _lastBlockObject;
    public UnityEvent UnituEvent;
    public GameObject CollectedCubeText;
    private void Start()
    {
        UpdateLastBlockObject();
        InitializedStackControllerByCube();
    }

    public void IncreaseBlockStack(GameObject gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + gameObject.transform.localScale.y, transform.position.z);
        gameObject.transform.position = new Vector3(_lastBlockObject.transform.position.x, _lastBlockObject.transform.position.y - gameObject.transform.localScale.y, _lastBlockObject.transform.position.z);
        gameObject.transform.SetParent(transform);
        BlockList.Add(gameObject);
        UpdateLastBlockObject();

        UnituEvent.Invoke();
    }
    public void DekreaseBlockStack(GameObject gameObject)
    {
        gameObject.transform.parent = null;
        BlockList.Remove(gameObject);
        UpdateLastBlockObject();
    }
    private void UpdateLastBlockObject()
    {
        _lastBlockObject = BlockList[BlockList.Count - 1];
    }
    public void SetCollectedCubeText()
    {
        Instantiate(CollectedCubeText, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
    }
    public void InitializedStackControllerByCube()
    {
        EventManager.DoStack(this);
    }
}
