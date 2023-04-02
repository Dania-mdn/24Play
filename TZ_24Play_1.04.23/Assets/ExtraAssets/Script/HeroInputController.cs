using UnityEngine;

public class HeroInputController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [HideInInspector] public bool IsMoveng = false;
    [HideInInspector] public float PositionX;

    private void OnEnable()
    {
        GameManager.EndGame += EndGame;
    }
    private void OnDisable()
    {
        GameManager.EndGame -= EndGame;
        EndGame();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (IsMoveng == false)
            {
                IsMoveng = true;
                _gameManager.StartGameMethod();
            }
        }

        float halfScreen = Screen.width / 2;
        PositionX = (Input.mousePosition.x - halfScreen) / halfScreen* 3;
    }
    private void EndGame()
    {
        IsMoveng = false;
        enabled = false;
    }
}
