using UnityEngine;

public class Regdoll : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody[] _allRigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _allRigidbody = GetComponentsInChildren<Rigidbody>();
    }
    public void DisableKinematicInChildren()
    {
        _animator.enabled = false;

        foreach (Rigidbody rigitbodiOfCildren in _allRigidbody)
        {
            rigitbodiOfCildren.isKinematic = false;
            rigitbodiOfCildren.AddForce(Vector3.forward * (PlayerPrefs.GetFloat("InertiaForRegdoll") + 3), ForceMode.Impulse);
        }

        transform.parent = null;
    }
}
