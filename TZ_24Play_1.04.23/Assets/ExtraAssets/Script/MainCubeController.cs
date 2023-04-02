using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCubeController : MonoBehaviour
{
    public Regdoll Regdoll;
    private Vector3 _direction = Vector3.forward;
    private RaycastHit hit;
    private Vector3[] _StartPositionForRaycast = new Vector3[2];
    private bool _isEnd = false;
    private void CheacPositionRaycast()
    {
        float halfsize = transform.localScale.x / 2 - 0.1f;
        _StartPositionForRaycast[0] = transform.position + new Vector3(halfsize, halfsize);
        _StartPositionForRaycast[1] = transform.position + new Vector3(-halfsize, halfsize);
    }
    private void FixedUpdate()
    {
        SetCubeRaycast();
    }
    private void SetCubeRaycast()
    {
        if (_isEnd) return;

        CheacPositionRaycast();

        for (int i = 0; i < _StartPositionForRaycast.Length; i++)
        {
            if (Physics.Raycast(_StartPositionForRaycast[i], _direction, out hit, 1))
            {
                if (hit.transform.CompareTag("CubeWall"))
                {
                    Regdoll.DisableKinematicInChildren();
                    _isEnd = transform;
                }
            }
        }
    }
}
