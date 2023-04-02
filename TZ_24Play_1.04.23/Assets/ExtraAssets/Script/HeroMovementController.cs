using UnityEngine;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private GameObject _trackGround;
    [SerializeField] private HeroInputController HeroInputController;

    [Range(1, 20)]
    [SerializeField] private float _muvementSpeed = 1.0f;

    private void Update()
    {
        if (HeroInputController.IsMoveng)
        {
            transform.Translate(Vector3.forward * _muvementSpeed * Time.deltaTime);
            MoveHorizontal(HeroInputController.PositionX);
        }
    }
    private void MoveHorizontal(float xpos)
    {
        float minX = -(_trackGround.transform.localScale.x - transform.localScale.x) / 2;
        float maxX = (_trackGround.transform.localScale.x - transform.localScale.x) / 2;
        float clampedX = Mathf.Clamp(xpos, minX, maxX);

        transform.localPosition = new Vector3(clampedX, transform.localPosition.y, transform.localPosition.z);
    }
}
