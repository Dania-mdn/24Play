using UnityEngine;

public class CubeController : MonoBehaviour
{
    private HeroStackController _heroStackController;
    private Vector3 _direction = Vector3.back;
    private bool _isStac = false;
    private RaycastHit hit;
    private Vector3[] _StartPositionForRaycast = new Vector3[2];
    private void OnEnable()
    {
        EventManager.NewGameobjectStack += InitializeHerrostackController;
    }
    private void OnDisable()
    {
        EventManager.NewGameobjectStack -= InitializeHerrostackController;
    }
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
        CheacPositionRaycast();

        for (int i = 0; i < _StartPositionForRaycast.Length; i++)
        {
            if(Physics.Raycast(_StartPositionForRaycast[i], _direction, out hit, 1))
            {
                if (!_isStac)
                {
                    _isStac = true;
                    _heroStackController.IncreaseBlockStack(gameObject);
                    SetDirection();
                }
                if (hit.transform.CompareTag("CubeWall"))
                {
                    _heroStackController.DekreaseBlockStack(gameObject);
                    Invoke("Destroy", 3);
                }
            }
        }
    }
    private void SetDirection()
    {
        _direction = Vector3.forward;
    }
    private void InitializeHerrostackController(HeroStackController HeroController)
    {
        _heroStackController = HeroController;
    }
    private void Destroy() => Destroy(gameObject);
}
