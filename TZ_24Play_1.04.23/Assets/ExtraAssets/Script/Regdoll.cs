using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regdoll : MonoBehaviour
{
    public Animator Animator;
    private Rigidbody[] _allRigidbody;
    private void Start()
    {
        _allRigidbody = GetComponentsInChildren<Rigidbody>();
    }
    public void DisableKinematicInChildren()
    {
        Animator.enabled = false;
        foreach (Rigidbody rb in _allRigidbody)
        {
            rb.isKinematic = false;
            rb.AddForce(Vector3.forward * (PlayerPrefs.GetFloat("InertiaForRegdoll") + 3), ForceMode.Impulse);
        }
        transform.parent = null;
    }
}
