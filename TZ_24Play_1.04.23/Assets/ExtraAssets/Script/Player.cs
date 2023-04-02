using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _muveTransform;

    [Range(1, 20)]
    [SerializeField] private float speed = 1.0f;
    private bool _isMoveng = false;

    [SerializeField] private GameObject _trackGround;
    [SerializeField] private ParticleSystem _warpEffect;
    [SerializeField] private GameObject _tapToPlay;
    [SerializeField] private GameObject _EndGame;
    private void OnEnable()
    {
        EventManager.Stack += SetEffect;
        EventManager.EndGame += EndGame;
    }
    private void OnDisable()
    {
        EventManager.Stack -= SetEffect;
        EventManager.EndGame -= EndGame;
    }
    private void Start()
    {
        _warpEffect.Stop();
        PlayerPrefs.SetFloat("InertiaForRegdoll", speed);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move();

            if (_isMoveng == false)
            {
                _isMoveng = true;
                EventManager.DoStackComplite();
            }
        }

        if (_isMoveng)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            _tapToPlay.SetActive(false);
        }
        else
        {
            transform.Translate(Vector3.forward * 0 * Time.deltaTime);
            _warpEffect.Stop();
        }
    }
    private void Move()
    {
        float halfScreen = Screen.width / 2;
        float xPosition = (Input.mousePosition.x - halfScreen) / halfScreen * 2;
        float minX = -(_trackGround.transform.localScale.x - transform.localScale.x) / 2;
        float maxX = (_trackGround.transform.localScale.x - transform.localScale.x) / 2;
        float clampedX = Mathf.Clamp(xPosition, minX, maxX);

        _muveTransform.localPosition = new Vector3(clampedX, _muveTransform.localPosition.y, _muveTransform.localPosition.z);
    }
    private void SetEffect()
    {
        _warpEffect.Play();
    }
    private void EndGame()
    {
        _isMoveng = false;
        _EndGame.SetActive(true);
    }
}
